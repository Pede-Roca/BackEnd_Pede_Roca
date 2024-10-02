using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Chave primária
            builder.HasKey(t => t.Id);

            // Propriedades
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            // Seed Data (dados iniciais)
            builder.HasData(
                new Categoria
                {
                    Id = Guid.NewGuid(),
                    Nome = "Eletrônicos"
                },
                new Categoria
                {
                    Id = Guid.NewGuid(),
                    Nome = "Material Escolar"
                }
            );
        }
    }
}
