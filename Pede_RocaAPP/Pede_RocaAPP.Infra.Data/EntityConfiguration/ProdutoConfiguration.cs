using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;
using System;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.Estoque)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.FatorPromocao)
                .IsRequired();

            builder.Property(p => p.UidFoto)
                .HasMaxLength(250);

            // Relacionamento com Categoria
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.IdCategoria)
                .IsRequired();

            // Relacionamento com Unidade de Medida
            builder.HasOne(p => p.UnidadeMedida)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.IdUnidade)
                .IsRequired();

            // Seed Data
            builder.HasData(
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Produto Exemplo",
                    Descricao = "Descrição do Produto Exemplo",
                    Preco = 49.99m,
                    Status = true,
                    Estoque = 100,
                    FatorPromocao = 1.0m,
                    UidFoto = "imagem_exemplo.jpg",
                    IdCategoria = Guid.NewGuid(),
                    IdUnidade = Guid.NewGuid()
                }
            );
        }
    }
}
