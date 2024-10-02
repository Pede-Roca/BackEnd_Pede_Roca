using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            // Definindo a chave primária
            builder.HasKey(t => t.Id);

            // Definindo propriedades
            builder.Property(t => t.Nota)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(t => t.Descricao)
                .HasMaxLength(500);

            // Configurando corretamente as chaves estrangeiras e as propriedades de navegação
            builder.HasOne(t => t.Usuario)
                .WithMany(u => u.Avaliacoes)
                .HasForeignKey(t => t.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.CarrinhoCompra)
                .WithMany(c => c.Avaliacoes)
                .HasForeignKey(t => t.IdCarrinhoCompra)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Dados de Seed
            builder.HasData(
                new Avaliacao
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Nota = 5,
                    Descricao = "Excelente produto",
                    IdUsuario = Guid.NewGuid(), // Exemplo: deve ser o ID do usuário existente
                    IdCarrinhoCompra = Guid.NewGuid() // Exemplo: deve ser o ID do carrinho existente
                }
            );
        }
    }
}
