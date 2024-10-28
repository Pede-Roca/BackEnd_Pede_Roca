using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class CarrinhoCompraConfiguration : IEntityTypeConfiguration<CarrinhoCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompra> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(cc => cc.Data)
                .IsRequired();

            builder.Property(cc => cc.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Configurando o relacionamento com Usuario
            builder.HasOne(cc => cc.Usuario)
                .WithMany()
                .HasForeignKey(cc => cc.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Configurando o relacionamento muitos-para-muitos com ProdutosPedido
            builder.HasMany(cc => cc.CarrinhoComprasProdutosPedido)
                .WithOne(cp => cp.CarrinhoCompra)
                .HasForeignKey(cp => cp.IdCarrinhoCompra);
        }
    }
}
