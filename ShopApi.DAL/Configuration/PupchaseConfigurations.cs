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
            builder.Property(d => d.Type)
                .HasMaxLength(40);
            builder.Property(d => d.Prise)
                .HasMaxLength(40);
            builder.Property(d => d.Type)
                .HasMaxLength(40);
            builder.Property(d => d.Description)
                .HasMaxLength(40);
            builder.Property(d => d.Volume)
                .HasMaxLength(40);
        }
    }
}
