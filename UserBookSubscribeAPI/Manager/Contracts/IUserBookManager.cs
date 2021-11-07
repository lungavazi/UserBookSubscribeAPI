using System.Collections.Generic;
using UserBookSubscribeAPI.Models.DTO;

namespace UserBookSubscribeAPI.Manager
{
    public interface IUserBookManager
    {
        public List<UserDTO> GetUsers();
        public UserDTO GetUserById(long userId);
        public List<BookDTO> GetBooks();
        public BookDTO GetBookById(long bookId);
        public void AddBook(BookAddDTO bookDTO);
        public void AddUser(UserAddDTO userDTO);
        public void Subscribe(long userID, long bookID, out string resultsMsg);
        public void Unsubscribe(long userID, long bookID, out string resultsMsg);
        public UserDTO AuthenticateUser(string userName, string password);
        public List<BookSubscriptionsDTO> BookSubscriptions();
        public List<UserSubscriptionsDTO> UserSubscriptions();
    }
}
