using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Domain.Entity;

namespace ShopApi.DAL.Configuration
{
    public class Employeeconfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Address).HasMaxLength(40);
            builder.Property(d => d.NameEmployee).IsRequired().HasMaxLength(40);
            builder.Property(d => d.Login).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Password).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Status).HasDefaultValue("user").HasMaxLength(50);

            builder.HasMany<Bascket>(x => x.Basckets)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
