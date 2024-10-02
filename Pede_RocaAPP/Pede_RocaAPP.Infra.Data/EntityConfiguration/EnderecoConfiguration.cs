using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            // Chave primária
            builder.HasKey(e => e.Id);

            // Propriedades
            builder.Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(9);  // MaxLength de 9 para incluir o formato com hífen (XXXXX-XXX)

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(2);  // MaxLength de 2 para siglas de estados brasileiros (ex: SP, RJ)

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Complemento)
                .HasMaxLength(150);  // Campo opcional

            // Configuração da chave estrangeira
            builder.HasOne(e => e.Usuario)
                .WithMany(u => u.Enderecos) // Um Usuario pode ter muitos Enderecos
                .HasForeignKey(e => e.IdUsuario) // Chave estrangeira na Endereco
                .IsRequired() // O relacionamento é obrigatório
                .OnDelete(DeleteBehavior.NoAction); // Ação de exclusão: não faz nada
        }
    }
}
