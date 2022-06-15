using Microsoft.EntityFrameworkCore;

namespace Web_Api.DATA.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions ):base(dbContextOptions)
        {
                
        }
        public DbSet<Product> Products { get; set; }
    }
}
