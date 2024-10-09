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
                .WithMany() // Supondo que você tenha uma coleção de CarrinhosCompra no Usuario
                .HasForeignKey(cc => cc.IdUsuario) // Define a chave estrangeira
                .IsRequired() // Define que a chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction);

            // Configurando o relacionamento com ProdutosPedido
            builder.HasOne(cc => cc.ProdutosPedido) // Define a propriedade de navegação para ProdutosPedido
                .WithMany() // Supondo que você tenha uma propriedade CarrinhoCompra no ProdutosPedido
                .HasForeignKey(cc => cc.IdProdutosPedido) // Define a chave estrangeira
                .IsRequired() // Define que a chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction);
        }       
    }
}
