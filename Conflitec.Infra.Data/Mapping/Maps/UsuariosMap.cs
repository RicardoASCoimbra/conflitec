using Conflitec.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Conflitec.Infra.Data.Mapping.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Sobrenome).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Escolaridade).IsRequired();
            builder.Property(x => x.Excluido).HasDefaultValue(false);
            builder.HasKey(x => x.Id);
        }
    }
}
