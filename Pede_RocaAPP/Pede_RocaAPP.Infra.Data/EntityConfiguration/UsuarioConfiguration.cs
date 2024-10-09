using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Telefone)
                .HasMaxLength(15);

            builder.Property(t => t.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(t => t.DataNascimento)
                .IsRequired();

            builder.Property(t => t.NivelAcesso)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.UidFotoPerfil)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Status)
                .IsRequired();

            builder.Property(t => t.CreateUserDate)
                .IsRequired();
        }
    }
}
