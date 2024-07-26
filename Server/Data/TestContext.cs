using Integrador.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integrador.Server.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> option) : base(option)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Empresa> Empresa { get; set; }// Cambia el nombre del DbSet a Usuarios

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(o =>
            {
                o.HasKey(x => x.IdUsuario);
                o.ToTable("Usuario");  // Especifica el nombre de la tabla en la base de datos
            });
            modelBuilder.Entity<Categoria>(e =>
            {
                e.HasKey(x => x.IdCategoria);
                e.ToTable("Categoria");  // Especifica el nombre de la tabla en la base de datos
            });
            modelBuilder.Entity<Empresa>(e =>
            {
                e.HasKey(x => x.IdEmpresa);
                e.ToTable("Empresa");  // Especifica el nombre de la tabla en la base de datos
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
