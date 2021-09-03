using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using UserBookSubscribeAPI.Context;
using UserBookSubscribeAPI.Service.Contracts;

namespace UserBookSubscribeAPI.Service.Repository
{
    public class BaseClassRepository<T> : IBaseClassRepository<T> where T : class
    {
        private UserBookSubscribeContext  _userBookSubscribeContext { get; set; }

        public BaseClassRepository(UserBookSubscribeContext userBookSubscribeContext)
        {
            _userBookSubscribeContext = userBookSubscribeContext;
        }
        public void Create(T entity)
        {
            _userBookSubscribeContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _userBookSubscribeContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _userBookSubscribeContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _userBookSubscribeContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _userBookSubscribeContext.Set<T>().Update(entity);
        }

        public void Save()
        {
            _userBookSubscribeContext.SaveChanges();
        }
    }
}
