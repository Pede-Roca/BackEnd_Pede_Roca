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

            // Configuração da chave estrangeira
            
            builder.HasOne(e => e.Usuario)
                .WithMany() // Não é necessário que Usuario tenha a coleção de endereços
                .HasForeignKey(e => e.IdUsuario) // Chave estrangeira de Endereco para Usuario
                .IsRequired() // Relacionamento obrigatório
                .OnDelete(DeleteBehavior.NoAction); // Não remover em cascata

            builder.HasOne(t => t.CarrinhoCompra)
                .WithMany()
                .HasForeignKey(t => t.IdCarrinhoCompra)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
