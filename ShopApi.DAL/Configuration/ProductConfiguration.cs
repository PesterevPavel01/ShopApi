using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;
using System.Reflection.Metadata;

namespace ShopApi.DAL.Configuration
{
    internal class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Price)
            .HasMaxLength(40);
            builder.Property(d => d.Firm)
            .HasMaxLength(40);

            builder.HasMany<Bascket>(x => x.Basckets)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
