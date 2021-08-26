using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserBookSubscribeAPI.Entities;
using UserBookSubscribeAPI.Entities.DTO;
using UserBookSubscribeAPI.Service.Contracts;

namespace UserBookSubscribeAPI.Manager
{
    public class UserBookManager: IUserBookManager
    {
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private ISubscribeRepository _subscribeRepository;
        private IMapper _mapper;
        private const string SECRET_KEY = "MyFirstJWTAPISecretKeyAuthentication";
        public static SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public UserBookManager(IBookRepository bookRepository, IMapper mapper, IUserRepository userRepository, ISubscribeRepository subscribeRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _subscribeRepository = subscribeRepository;
        }

        public List<UserDTO> GetUsers()
        {
                var results = _userRepository.FindAll();
                return _mapper.Map<List<UserDTO>>(results);
        }

        public UserDTO GetUserById(int userId)
        {
            var results = _userRepository.FindByCondition(c => c.UserId == userId).FirstOrDefault();
            return _mapper.Map<UserDTO>(results);
        }

        public List<BookDTO> GetBooks()
        {
                var results = _bookRepository.FindAll();
            _bookRepository.FindAll();
                return _mapper.Map<List<BookDTO>>(results);
        }

        public BookDTO GetBookById(int bookId)
        {
            var bookEntity = _bookRepository.FindByCondition(c => c.BookId == bookId).FirstOrDefault();
            int numberOfSubscriptions = _subscribeRepository.FindByCondition(c => c.BookID == bookId).Count();
            var bookDTO = _mapper.Map<BookDTO>(bookEntity);
            bookDTO.NumberOfSubscriptions = numberOfSubscriptions;

            return bookDTO;
        }

        public void AddBook(BookAddDTO bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);
            _bookRepository.Create(bookEntity);
            _bookRepository.Save();
        }

        public void AddUser(UserAddDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            _userRepository.Create(userEntity);
            _userRepository.Save();
        }

        public void Subscribe(int userId, int bookId, out string responseMsg)
        {
            if (_subscribeRepository.FindByCondition(c => c.UserID == userId && c.BookID == bookId).FirstOrDefault() != null){
                responseMsg = "Subscription already exists";
            }
            else if (_userRepository.FindByCondition(d => d.UserId == userId).FirstOrDefault() != null && _bookRepository.FindByCondition(c => c.BookId == bookId).FirstOrDefault() != null)
            {
                SubscribeDTO subscribeDTO = new SubscribeDTO { BookID = bookId, UserID = userId };
                var subscribeEntity = _mapper.Map<Subscribe>(subscribeDTO);
                _subscribeRepository.Subscribe(subscribeEntity);
                _subscribeRepository.Save();
                responseMsg = "User subscribed";
            }
            else { responseMsg = "Either the User or the Book Id does not exist."; }            
        }

        public void Unsubscribe(int userId, int bookId, out string responseMsg)
        {
            var subscribeEntity = _subscribeRepository.FindByCondition(c => c.UserID == userId && c.BookID == bookId).FirstOrDefault();

            if (subscribeEntity != null)
            {                
                _subscribeRepository.Unsubscribe(subscribeEntity);
                _subscribeRepository.Save();
                responseMsg = "User Unsubscripted";
            }
            else
            {
                responseMsg = "User subscription does not exist.";
            }
        }

        public UserDTO AuthenticateUser(string userName, string password)
        {
            var results = _userRepository.FindByCondition(c => c.EmailAddress == userName && c.Password == password).FirstOrDefault();
            if (results != null)
            {
                var userDTO = _mapper.Map<UserDTO>(results);
                var jwt = GenerateToken(userName);
                userDTO.Token = jwt;
                return userDTO;
            }
            else { return new UserDTO(); }
        }

        private string GenerateToken(string username)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
