using AssessmentGaleria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessmentGaleria.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c=> c.Id);
            builder.Property(c=> c.Id).ValueGeneratedOnAdd();

            builder.Property(c=> c.Nome).IsRequired().HasMaxLength(50);
            builder.Property(c=> c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c=> c.Senha).IsRequired().HasMaxLength(50);
        }
    }
     
}
