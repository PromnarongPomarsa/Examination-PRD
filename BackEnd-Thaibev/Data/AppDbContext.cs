using BackEnd_Thaibev.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Thaibev.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for your entities here
        public DbSet<TbMMsg> tb_m_msg { get; set; }
        // Example:
        // public DbSet<Product> Products { get; set; }

    }
}
