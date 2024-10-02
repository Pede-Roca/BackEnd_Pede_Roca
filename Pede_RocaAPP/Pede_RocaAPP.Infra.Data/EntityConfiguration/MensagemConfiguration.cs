using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class MensagemConfiguration : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            // Chave primária
            builder.HasKey(m => m.Id);

            // Propriedades
            builder.Property(m => m.Data)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(255); // Definindo tamanho máximo para o e-mail

            builder.Property(m => m.Conteudo)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(m => m.UidAnexo)
                .HasMaxLength(255); // Opcional, com tamanho máximo definido para o anexo

            builder.Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(7);

            // Relacionamento
            builder.HasOne(m => m.IdUsuario)
                .WithMany()
                .HasForeignKey("IdUsuario")
                .IsRequired();

            // Exemplo de Seed Data (dados iniciais)
            builder.HasData(
                new Mensagem
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Email = "usuario@example.com",
                    Conteudo = "Esta é uma mensagem de exemplo.",
                    Status = "Enviado",
                    UidAnexo = "anexo-123",
                    IdUsuario = new Usuario { /* Dados do usuário de exemplo */ }
                }
            );
        }
    }
}
