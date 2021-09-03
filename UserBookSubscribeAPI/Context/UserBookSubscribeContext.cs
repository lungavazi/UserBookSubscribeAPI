using Microsoft.EntityFrameworkCore;
using UserBookSubscribeAPI.Entities;

namespace UserBookSubscribeAPI.Context
{
    public class UserBookSubscribeContext: DbContext
    {
        public UserBookSubscribeContext(DbContextOptions<UserBookSubscribeContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
    }
}
