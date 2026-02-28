using Microsoft.EntityFrameworkCore;

namespace BackEnd_Thaibev.Data
{
    public class AbbDbContext : DbContext
    {
        public AbbDbContext(DbContextOptions<AbbDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for your entities here
        // Example:
        // public DbSet<Product> Products { get; set; }

    }
}
