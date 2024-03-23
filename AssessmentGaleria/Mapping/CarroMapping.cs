using AssessmentGaleria.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AssessmentGaleria.Mapping
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Modelo).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Info).IsRequired().HasMaxLength(1024);
            builder.Property(c => c.Ano).IsRequired();
            builder.Property(c => c.Imagem).IsRequired().HasMaxLength(1024);
        }
    }
}


