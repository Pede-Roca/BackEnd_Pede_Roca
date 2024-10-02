using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100); // Ajuste o tamanho máximo conforme necessário

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100); // Ajuste o tamanho máximo conforme necessário
            
            builder.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(200); // Ajuste o tamanho máximo conforme necessário

            builder.Property(t => t.Telefone)
                .HasMaxLength(15); // Ajuste o tamanho máximo conforme necessário
            
            builder.Property(t => t.CPF)
                .IsRequired()
                .HasMaxLength(11); // Ajuste o tamanho máximo conforme necessário

            builder.Property(t => t.DataNascimento)
                .IsRequired();

            builder.Property(t => t.NivelAcesso)
                .IsRequired()
                .HasMaxLength(50); // Ajuste o tamanho máximo conforme necessário

            builder.Property(t => t.UidFotoPerfil)
                .IsRequired()
                .HasMaxLength(200); // Ajuste o tamanho máximo conforme necessário

            builder.Property(t => t.Status)
                .IsRequired();

            builder.Property(t => t.CreateUserDate)
                .IsRequired();

            // Relacionamento com Endereco (se houver)
            builder.HasMany(t => t.Enderecos)
                .WithOne() // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey("UsuarioId"); // Altere se o nome da chave estrangeira for diferente

            // Dados iniciais de exemplo (ajuste conforme necessário)
            builder.HasData(
                new Usuario("John Doe", "john.doe@example.com", "senha123", "123456789", "12345678900", new DateTime(1990, 1, 1), "Admin", "uidFotoPerfil1", true, DateTime.Now),
                new Usuario("Jane Smith", "jane.smith@example.com", "senha456", "987654321", "09876543210", new DateTime(1995, 5, 5), "User", "uidFotoPerfil2", true, DateTime.Now)
            );
        }
    }
}
