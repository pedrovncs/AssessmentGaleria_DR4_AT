using AssessmentGaleria.Models;
using AssessmentGaleria.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AssessmentGaleria
{
    public class GaleriaDBContext : DbContext
    {
        public DbSet<Models.Fabricante> Fabricantes { get; set; }
        public DbSet<Models.Carro> Carros { get; set; }
        public DbSet<Models.Usuario> Usuarios { get; set; }

        public GaleriaDBContext(DbContextOptions<GaleriaDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FabricanteMapping());
            modelBuilder.ApplyConfiguration(new CarroMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
