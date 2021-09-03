using UserBookSubscribeAPI.Context;
using UserBookSubscribeAPI.Entities;
using UserBookSubscribeAPI.Service.Contracts;

namespace UserBookSubscribeAPI.Service.Repository
{
    public class UserRepository : BaseClassRepository<User>, IUserRepository
    {
        public UserRepository(UserBookSubscribeContext userBookSubscribeContext)
            :base(userBookSubscribeContext)
        { 
            
        }
    }
}
