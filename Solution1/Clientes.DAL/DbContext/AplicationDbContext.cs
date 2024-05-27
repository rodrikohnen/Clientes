using Clientes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAL.Dbcontext
{
    public class AplicationDbContext : IdentityDbContext
    { 
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedClientes.Seed(modelBuilder);            
        }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
