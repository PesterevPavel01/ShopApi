using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.DAL.Configuration
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.NameCategory)
            .HasMaxLength(40);
            builder.Property(d => d.ExtraCharge)
            .HasMaxLength(40);
            builder.Property(d => d.Description)
            .HasMaxLength(40);
        }
    }
}
