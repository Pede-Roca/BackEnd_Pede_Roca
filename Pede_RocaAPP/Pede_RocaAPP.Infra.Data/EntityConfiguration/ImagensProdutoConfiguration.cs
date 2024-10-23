using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.EntityConfiguration
{
    public class ImagensProdutosConfiguration : IEntityTypeConfiguration<ImagensProdutos>
    {
        public void Configure(EntityTypeBuilder<ImagensProdutos> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
