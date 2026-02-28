using BackEnd_Thaibev.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Thaibev.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TbMMsg> tb_m_msg { get; set; }
        public DbSet<TbTQuestion> tb_t_question { get; set; }

    }
}
