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

            builder.HasOne(pp => pp.Produto)
                .WithMany(p => p.ProdutosPedidos) // Assumindo que um produto pode estar em muitos pedidos
                .HasForeignKey(p => p.IdProduto) // Chave estrangeira na ProdutosPedido
                .IsRequired() // O relacionamento é obrigatório
                .OnDelete(DeleteBehavior.NoAction); // Ação de exclusão
        }
    }
}
