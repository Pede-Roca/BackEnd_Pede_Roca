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

            // Aqui você pode configurar um relacionamento se necessário.
            builder.HasMany(t => t.IdProduto)
                .WithOne() // Altere isso se houver uma navegação de volta em Produto.
                .HasForeignKey("ProdutoId"); // Altere se o nome da chave estrangeira for diferente.

            // Se você quiser adicionar dados iniciais, pode usar HasData
            // Aqui está um exemplo fictício, ajuste conforme necessário
            builder.HasData(
                new ProdutosPedido(2, new List<Produto>()) // Altere para incluir objetos Produto válidos
            );
        }
    }
}
