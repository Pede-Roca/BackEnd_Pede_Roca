using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Nota)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(t => t.Descricao)
                .HasMaxLength(500);

            builder.HasOne(t => t.IdUsuario)
                .WithMany()
                .HasForeignKey("IdUsuario")
                .IsRequired();

            builder.HasOne(t => t.IdCarrinhoCompra)
                .WithMany()
                .HasForeignKey("IdCarrinhoCompra")
                .IsRequired();
            
            builder.HasData(
                new Avaliacao
                {
                    Id = Guid.NewGuid(),
                    Nota = 5,
                    Descricao = "Excelente produto",
                    IdUsuario = new Usuario { /* Dados do usuário */ },
                    IdCarrinhoCompra = new CarrinhoCompra { /* Dados do carrinho */ }
                }
            );
        }
    }
}
