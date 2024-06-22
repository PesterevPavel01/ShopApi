using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.DAL.Configuration 
{ 
    internal class BascketConfiguration:IEntityTypeConfiguration<Bascket>
    {
        public void Configure(EntityTypeBuilder<Bascket> builder)
        {
            builder.HasKey(d => d.Id);    
        }
    }
}
