
namespace UserBookSubscribeAPI.Models.DTO
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
