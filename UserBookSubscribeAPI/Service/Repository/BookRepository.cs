using UserBookSubscribeAPI.Context;
using UserBookSubscribeAPI.Entities;
using UserBookSubscribeAPI.Service.Contracts;

namespace UserBookSubscribeAPI.Service.Repository
{
    public class BookRepository : BaseClassRepository<Book>, IBookRepository
    {
        public BookRepository(UserBookSubscribeContext userBookSubscribeContext )
            : base(userBookSubscribeContext)
        {

        }
    }
}
