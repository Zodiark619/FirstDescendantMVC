using FirstDescendantMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstDescendantMVC.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
