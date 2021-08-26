using System.Collections.Generic;
using UserBookSubscribeAPI.Entities.DTO;

namespace UserBookSubscribeAPI.Manager
{
    public interface IUserBookManager
    {
        public List<UserDTO> GetUsers();
        public UserDTO GetUserById(int userId);
        public List<BookDTO> GetBooks();
        public BookDTO GetBookById(int bookId);
        public void AddBook(BookAddDTO bookDTO);
        public void AddUser(UserAddDTO userDTO);
        public void Subscribe(int userID, int bookID, out string resultsMsg);
        public void Unsubscribe(int userID, int bookID, out string resultsMsg);
        public UserDTO AuthenticateUser(string userName, string password);
    }
}
