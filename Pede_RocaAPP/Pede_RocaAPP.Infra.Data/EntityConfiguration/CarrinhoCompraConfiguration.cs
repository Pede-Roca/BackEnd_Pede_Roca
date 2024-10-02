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
            builder.HasKey(t => t.Id); // Define a chave primária

            builder.Property(cc => cc.Data)
                .IsRequired(); // Define que a Data é obrigatória

            builder.Property(cc => cc.Status)
                .IsRequired()
                .HasMaxLength(50); // Define que o Status é obrigatório e tem um comprimento máximo

            // Configurando o relacionamento com Usuario
            builder.HasOne(cc => cc.Usuario) // Define a propriedade de navegação para Usuario
                .WithMany(u => u.CarrinhoCompra) // Supondo que você tenha uma coleção de CarrinhosCompra no Usuario
                .HasForeignKey(cc => cc.IdUsuario) // Define a chave estrangeira
                .IsRequired() // Define que a chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction);

            // Configurando o relacionamento com ProdutosPedido
            builder.HasMany(cc => cc.ProdutosPedido) // Define a propriedade de navegação para ProdutosPedido
                .WithOne(pp => pp.CarrinhoCompra) // Supondo que você tenha uma propriedade CarrinhoCompra no ProdutosPedido
                .HasForeignKey(pp => pp.IdCarrinhoCompra) // Define a chave estrangeira
                .IsRequired() // Define que a chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction);

            // Configurando o relacionamento com Avaliacao
            builder.HasMany(cc => cc.Avaliacoes) // Define a propriedade de navegação para Avaliacao
                .WithOne(a => a.CarrinhoCompra) // Supondo que você tenha uma propriedade CarrinhoCompra na Avaliacao
                .HasForeignKey(a => a.IdCarrinhoCompra) // Define a chave estrangeira
                .IsRequired() // Define que a chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction);

            // Dados de Seed
            builder.HasData(
                new CarrinhoCompra
                {
                    Id = Guid.Parse("98765432-1234-5678-9876-543210987654"),
                    Data = DateTime.Now,
                    Status = "Em andamento",
                    IdUsuario = Guid.Parse("5555555-5555-5555-5555-555555555555")
                }
            );
        }       
    }
}
