using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class PlanoAssinaturaConfiguration : IEntityTypeConfiguration<PlanoAssinatura>
    {
        public void Configure(EntityTypeBuilder<PlanoAssinatura> builder)
        {
            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Ativo)
                .IsRequired();

            // Relacionamento
            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
