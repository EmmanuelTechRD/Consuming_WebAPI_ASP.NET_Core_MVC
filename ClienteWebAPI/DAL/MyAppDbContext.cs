using ClienteWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteWebAPI.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
