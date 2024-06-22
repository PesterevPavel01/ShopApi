using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.DAL.Configuration
{
    public class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.NumberPhone)
            .HasMaxLength(40);
            builder.Property(d => d.Fax)
            .HasMaxLength(40);
            builder.Property(d => d.Inn)
            .HasMaxLength(40);
            builder.Property(d => d.NameProvider)
           .HasMaxLength(40);
            builder.Property(d => d.additionally)
            .HasMaxLength(40);
        }
    }
}
