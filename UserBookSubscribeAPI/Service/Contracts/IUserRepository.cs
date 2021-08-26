using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBookSubscribeAPI.Entities;

namespace UserBookSubscribeAPI.Service.Contracts
{
    public interface IUserRepository : IBaseClassRepository<User>
    {
    }
}
