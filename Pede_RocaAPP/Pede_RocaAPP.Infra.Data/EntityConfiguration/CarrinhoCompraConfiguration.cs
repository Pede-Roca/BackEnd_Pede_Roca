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

            // Configurando o relacionamento muitos-para-muitos com ProdutosPedido
            builder.HasMany(cc => cc.CarrinhoComprasProdutosPedido) // Use o nome correto da propriedade de navegação
                .WithOne(cp => cp.CarrinhoCompra) // Configuração do lado oposto do relacionamento
                .HasForeignKey(cp => cp.IdCarrinhoCompra);
        }
    }
}
