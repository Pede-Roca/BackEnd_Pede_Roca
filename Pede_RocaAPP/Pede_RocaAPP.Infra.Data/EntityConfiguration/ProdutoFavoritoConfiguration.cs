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
            builder.HasOne(pf => pf.Produto)
                .WithMany(p => p.ProdutosFavoritos) // Se um produto pode ter muitos favoritos, altere para `WithMany(p => p.ProdutosFavoritos)` se houver uma coleção na classe Produto
                .HasForeignKey(pf => pf.IdProduto)
                .IsRequired() // Define que o IdProduto é obrigatório
                .OnDelete(DeleteBehavior.NoAction); // Define que a ação de exclusão é NoAction

            // Configurando o relacionamento com Usuario
            builder.HasOne(pf => pf.Usuario)
                .WithMany(u => u.ProdutosFavoritos) // Se um usuário pode ter muitos favoritos, altere para `WithMany(u => u.ProdutosFavoritos)` se houver uma coleção na classe Usuario
                .HasForeignKey(pf => pf.IdUsuario)
                .IsRequired() // Define que o IdUsuario é obrigatório
                .OnDelete(DeleteBehavior.NoAction);

            // Se desejar adicionar dados iniciais (opcional)
            builder.HasData(
                // Exemplo de dados iniciais
                new ProdutoFavorito
                {
                    Id = Guid.NewGuid(),
                    IdProduto = Guid.Parse("999999999-9999-9999-9999-999999999999"),
                    IdUsuario = Guid.Parse("5555555-5555-5555-5555-555555555555")
                }
            );
        }
    }
}
