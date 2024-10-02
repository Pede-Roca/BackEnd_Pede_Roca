using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class UnidadeMedidaConfiguration : IEntityTypeConfiguration<UnidadeMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadeMedida> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.NomeUnidade)
                .IsRequired()
                .HasMaxLength(100); // Ajuste o tamanho máximo conforme necessário

            builder.Property(t => t.SiglaUnidade)
                .IsRequired()
                .HasMaxLength(10); // Ajuste o tamanho máximo conforme necessário

            // Se você quiser adicionar dados iniciais, pode usar HasData
            builder.HasData(
                new UnidadeMedida("Kilograma", "kg"),
                new UnidadeMedida("Litro", "L"),
                new UnidadeMedida("Metro", "m")
            );
        }
    }
}
