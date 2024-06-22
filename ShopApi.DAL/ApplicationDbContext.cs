using Microsoft.EntityFrameworkCore;
using ShopApi.DAL.Interceptors;
using ShopApi.Domain.Entity;
using System.Reflection;

namespace ShopApi.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Provider> Providers { get; set; } = null!;
        public DbSet<Purchase> Purchase { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Bascket> Basckets { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.AddInterceptors(new DateInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Подключаем все конфигурации из сборки
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        }
    }
}
