using ApiWithCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWithCleanArchitecture.Infra.Data.EntitiesConfigurations
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Login);
            builder.Property(e => e.Login).IsRequired();
            builder.Property(e => e.Senha).IsRequired();
        }
    }
}
