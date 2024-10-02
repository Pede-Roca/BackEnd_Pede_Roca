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

            builder.HasMany(t => t.Enderecos)
                .WithOne(e => e.Usuario) // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey(u => u.IdUsuario) // Altere se o nome da chave estrangeira for diferente
                .OnDelete(DeleteBehavior.NoAction); // Altere conforme necessário

            builder.HasMany(t => t.Avaliacoes)
                .WithOne(a => a.Usuario) // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey(u => u.IdUsuario) // Altere se o nome da chave estrangeira for diferente
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.CarrinhoCompra)
                .WithOne(cc => cc.Usuario) // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey(u => u.IdUsuario) // Altere se o nome da chave estrangeira for diferente
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.Mensagens)
                .WithOne(m => m.Usuario) // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey(u => u.IdUsuario) // Altere se o nome da chave estrangeira for diferente
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.PlanosAssinatura)
                .WithOne(pa => pa.Usuario) // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey(u => u.IdUsuario) // Altere se o nome da chave estrangeira for diferente
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.ProdutosFavoritos)
                .WithOne(pf => pf.Usuario) // Ajuste se houver uma propriedade de navegação de volta
                .HasForeignKey(u => u.IdUsuario) // Altere se o nome da chave estrangeira for diferente
                .OnDelete(DeleteBehavior.NoAction);

            // Dados iniciais de exemplo (ajuste conforme necessário)
            builder.HasData(
                new Usuario
                {
                    Id = Guid.Parse("5555555-5555-5555-5555-555555555555"),
                    Nome = "Usuário Exemplo",
                    Email = "usuario@exemplo.com",
                    Senha = "123456",
                    Telefone = "11999999999",
                    CPF = "12345678901",
                    DataNascimento = DateTime.Now.AddYears(-20),
                    NivelAcesso = "Cliente",
                    UidFotoPerfil = "123456",
                    Status = true,
                    CreateUserDate = DateTime.Now
                }
            );
        }
    }
}
