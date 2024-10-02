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
                    Id = Guid.Parse("22222222-2222-2222-2222-2222222222222"),
                    Nome = "Eletrônicos"
                },
                new Categoria
                {
                    Id = Guid.Parse("22222222-2222-2222-3333-2222222222222"),
                    Nome = "Material Escolar"
                }
            );
        }
    }
}
