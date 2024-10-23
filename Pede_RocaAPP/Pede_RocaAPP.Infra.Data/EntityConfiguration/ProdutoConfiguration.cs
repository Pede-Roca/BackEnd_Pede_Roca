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
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Relacionamento com Unidade de Medida
            builder.HasOne(p => p.UnidadeMedida)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.IdUnidade)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Relacionamento com ImagensProdutos
            builder.HasOne(p => p.ImagensProduto)
                .WithMany(i => i.Produtos)
                .HasForeignKey(p => p.IdImagensProdutos)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.ProdutosPedidos)
                .WithOne(pp => pp.Produto)
                .HasForeignKey(pp => pp.IdProduto)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.ProdutosFavoritos)
                .WithOne(pf => pf.Produto)
                .HasForeignKey(pf => pf.IdProduto)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
