using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Database
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
            => Database.EnsureCreated();
    }
}
