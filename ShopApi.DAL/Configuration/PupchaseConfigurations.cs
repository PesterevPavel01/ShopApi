using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.DAL.Configuration
{
    public class PupchaseConfigurations : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.PurchaseType)
                .HasMaxLength(40);
            builder.Property(d => d.PurchasePrise)
                .HasMaxLength(40);
            builder.Property(d => d.PurchaseType)
                .HasMaxLength(40);
            builder.Property(d => d.PurchaseDescription)
                .HasMaxLength(40);
            builder.Property(d => d.PurchaseVolume)
                .HasMaxLength(40);
        }
    }
}
