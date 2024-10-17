using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class CarrinhoComprasProdutosPedidoConfiguration : IEntityTypeConfiguration<CarrinhoComprasProdutosPedido>
    {
        public void Configure(EntityTypeBuilder<CarrinhoComprasProdutosPedido> builder)
        {
            builder.HasKey(t => t.Id); // Define a chave primária

            // Configurando o relacionamento com CarrinhoCompra
            builder.HasOne(cpp => cpp.CarrinhoCompra) // Propriedade de navegação para CarrinhoCompra
                .WithMany(cc => cc.CarrinhoComprasProdutosPedido) // Assumindo que você vai ter uma coleção de CarrinhoComprasProdutos no CarrinhoCompra
                .HasForeignKey(cpp => cpp.IdCarrinhoCompra) // Chave estrangeira na CarrinhoComprasProdutosPedido
                .IsRequired() // A chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction); // Ação de exclusão

            // Configurando o relacionamento com ProdutosPedido
            builder.HasOne(cpp => cpp.ProdutosPedido) // Propriedade de navegação para ProdutosPedido
                .WithMany(pp => pp.CarrinhoComprasProdutosPedido) // Assumindo que você vai ter uma coleção de CarrinhoComprasProdutos no ProdutosPedido
                .HasForeignKey(cpp => cpp.IdProdutosPedido) // Chave estrangeira na CarrinhoComprasProdutosPedido
                .IsRequired() // A chave estrangeira é obrigatória
                .OnDelete(DeleteBehavior.NoAction); // Ação de exclusão
        }
    }
}
