using AssessmentGaleria.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AssessmentGaleria.Mapping
{
    public class FabricanteMapping : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Nacionalidade).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(200);

            builder.HasMany(c => c.Carros)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
