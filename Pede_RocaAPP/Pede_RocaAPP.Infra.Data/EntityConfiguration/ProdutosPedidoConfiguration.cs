using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class ProdutosPedidoConfiguration : IEntityTypeConfiguration<ProdutosPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutosPedido> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.QuantidadeProduto)
                .IsRequired();

            // Relacionamento com Produto
            builder.HasOne(pp => pp.Produto)
                .WithMany(p => p.ProdutosPedidos) // Um Produto pode estar em muitos ProdutosPedidos
                .HasForeignKey(pp => pp.IdProduto) // Define a chave estrangeira
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Relacionamento com CarrinhoComprasProdutosPedido
            builder.HasMany(pp => pp.CarrinhoComprasProdutosPedido) // Muitos CarrinhoComprasProdutosPedido podem referenciar um ProdutosPedido
                .WithOne(cpp => cpp.ProdutosPedido) // Um CarrinhoComprasProdutosPedido possui um ProdutosPedido
                .HasForeignKey(cpp => cpp.IdProdutosPedido) // Define a chave estrangeira
                .OnDelete(DeleteBehavior.NoAction); // Ação de exclusão
        }
    }
}
