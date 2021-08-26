using System;
using System.Linq;
using System.Linq.Expressions;
using UserBookSubscribeAPI.Entities;

namespace UserBookSubscribeAPI.Service.Contracts
{
    public interface ISubscribeRepository
    {
        void Subscribe(Subscribe  subscribe);
        void Unsubscribe(Subscribe subscribe);
        IQueryable<Subscribe> FindByCondition(Expression<Func<Subscribe, bool>> expression);
        void Save();
    }
}
