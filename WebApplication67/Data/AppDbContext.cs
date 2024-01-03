using Microsoft.EntityFrameworkCore;
using WebApplication67.Models;

namespace WebApplication67.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        public AppDbContext() { }

        public DbSet<Client> Clients { get; set; } 
        public DbSet<Commande> Commandes { get; set; }

    }
}
