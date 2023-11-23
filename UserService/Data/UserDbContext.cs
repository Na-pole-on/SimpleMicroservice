using Microsoft.EntityFrameworkCore;
using UserService.Data.Entities;

namespace UserService.Data
{
    public class UserDbContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
            => Database.EnsureCreated();
    }
}
