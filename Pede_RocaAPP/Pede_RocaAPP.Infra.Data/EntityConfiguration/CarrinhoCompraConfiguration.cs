using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class CarrinhoCompraConfiguration : IEntityTypeConfiguration<CarrinhoCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompra> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Data)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(t => t.IdUsuario)
                .WithMany()
                .HasForeignKey("IdUsuario")
                .IsRequired();

            builder.HasMany(t => t.IdProdutosPedido)
                .WithOne()
                .HasForeignKey("IdCarrinhoCompra");

            // Exemplo de dados iniciais (seed data)
            builder.HasData(
                new CarrinhoCompra
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Status = "Em Processamento",
                    IdUsuario = new Usuario { /* Dados do usuário */ },
                    IdProdutosPedido = new List<ProdutosPedido>
                    {
                        new ProdutosPedido
                        {
                            Id = Guid.NewGuid(),
                            QuantidadeProduto = 1,
                            IdProduto = new List<Produto>
                            {
                                new Produto { /* Dados do produto */ }
                            }
                        }
                    }
                }
            );
        }
    }
}
