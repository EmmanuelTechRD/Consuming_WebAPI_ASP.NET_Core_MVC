using CategoriaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoriaWebAPI.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
