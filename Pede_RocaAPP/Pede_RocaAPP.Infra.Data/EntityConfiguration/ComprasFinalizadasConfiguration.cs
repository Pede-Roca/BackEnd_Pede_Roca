using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class ComprasFinalizadasConfiguration : IEntityTypeConfiguration<ComprasFinalizadas>
    {
        public void Configure(EntityTypeBuilder<ComprasFinalizadas> builder)
        {
            // Chave primária
            builder.HasKey(t => t.Id);

            // Configuração das propriedades
            builder.Property(t => t.Data)
                .IsRequired();

            builder.Property(t => t.DataEntrega)
                .IsRequired(false);

            builder.Property(t => t.Status)
                .IsRequired();

            builder.Property(t => t.TipoEntrega)
                .IsRequired();

            builder.Property(t => t.TipoPagamento)
                .IsRequired();

            builder.Property(t => t.IdEndereco)
                .IsRequired();

            builder.Property(t => t.IdCarrinhoCompra)
                .IsRequired();

            // Configuração de relacionamento muitos-para-um com Endereco
            builder.HasOne(t => t.Endereco)
                .WithMany() // Altere para WithMany para indicar a relação de muitos para um
                .HasForeignKey(t => t.IdEndereco);

            // Configuração de relacionamento um-para-um com CarrinhoCompra
            builder.HasOne(t => t.CarrinhoCompra)
                .WithMany()
                .HasForeignKey(t => t.IdCarrinhoCompra);
        }
    }
}
