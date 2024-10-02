using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class ProdutoFavoritoConfiguration : IEntityTypeConfiguration<ProdutoFavorito>
    {
        public void Configure(EntityTypeBuilder<ProdutoFavorito> builder)
        {
            // Definindo a chave primária
            builder.HasKey(pf => pf.Id);

            // Configurando o relacionamento com Produto
            builder.HasOne<Produto>()
                .WithMany() // Se um produto pode ter muitos favoritos, altere para `WithMany(p => p.ProdutosFavoritos)` se houver uma coleção na classe Produto
                .HasForeignKey(pf => pf.IdProduto)
                .IsRequired(); // Define que o IdProduto é obrigatório

            // Configurando o relacionamento com Usuario
            builder.HasOne<Usuario>()
                .WithMany() // Se um usuário pode ter muitos favoritos, altere para `WithMany(u => u.ProdutosFavoritos)` se houver uma coleção na classe Usuario
                .HasForeignKey(pf => pf.IdUsuario)
                .IsRequired(); // Define que o IdUsuario é obrigatório

            // Se desejar adicionar dados iniciais (opcional)
            builder.HasData(
                // Exemplo de dados iniciais
                new ProdutoFavorito { 
                    Id = Guid.NewGuid(), 
                    IdProduto = new List<Produto> { /* Dados do produto */ }, 
                    IdUsuario = new Usuario { /* Dados da unidade de medida */ }
                }
            );
        }
    }
}
