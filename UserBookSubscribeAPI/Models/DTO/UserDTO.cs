using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBookSubscribeAPI.Entities.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
