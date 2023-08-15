using Microsoft.EntityFrameworkCore;
using API_Proyecto_DAWA.Models;

namespace API_Proyecto_DAWA.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
