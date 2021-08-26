using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserBookSubscribeAPI.Context;
using UserBookSubscribeAPI.Entities;
using UserBookSubscribeAPI.Entities.DTO;
using UserBookSubscribeAPI.Service.Contracts;

namespace UserBookSubscribeAPI.Service.Repository
{
    public class SubscribeRepository : ISubscribeRepository
    {
        private UserBookSubscribeContext _userBookSubscribeContext;
        private IMapper _mapper;
        public SubscribeRepository(UserBookSubscribeContext userBookSubscribeContext, IMapper mapper)
        {
            _userBookSubscribeContext = userBookSubscribeContext;
            _mapper = mapper;
        }

        public void Subscribe(Subscribe subscribe)
        {
            _userBookSubscribeContext.Subscribe.Add(subscribe);
        }

        public void Unsubscribe(Subscribe subscribe)
        {
            _userBookSubscribeContext.Subscribe.Remove(subscribe);
        }

        public IQueryable<Subscribe> FindByCondition(Expression<Func<Subscribe, bool>> expression)
        {
            return _userBookSubscribeContext.Subscribe.Where(expression).AsQueryable();
        }

        public void Save()
        {
            _userBookSubscribeContext.SaveChanges();
        }

    }
}
