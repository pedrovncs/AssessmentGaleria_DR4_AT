using AssessmentGaleria.Models;
using AssessmentGaleria.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AssessmentGaleria
{
    public class GaleriaDBContext : DbContext
    {
        public DbSet<Models.Fabricante> Fabricantes { get; set; }
        public DbSet<Models.Carro> Carros { get; set; }

        public GaleriaDBContext(DbContextOptions<GaleriaDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FabricanteMapping());
            modelBuilder.ApplyConfiguration(new CarroMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
