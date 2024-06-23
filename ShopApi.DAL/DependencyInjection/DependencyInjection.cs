using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApi.DAL.Interactors;
using ShopApi.DAL.Interceptors;
using ShopApi.Domain.Entity;
using ShopApi.Domain.Interfaces.Interactors;

namespace ShopApi.DAL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddDataAccessLayer(this IServiceCollection services,IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("AppDbConnectionString");

            services.AddSingleton<DateInterceptor>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            services.InitInteractors();
        }

        private static void InitInteractors(this IServiceCollection services)
        {
            services.AddScoped<ICommonInteractor<Product>, CommonInteractor<Product>>();
            services.AddScoped<ICommonInteractor<Bascket>, CommonInteractor<Bascket>>();
            services.AddScoped<ICommonInteractor<Category>, CommonInteractor<Category>>();
            services.AddScoped<ICommonInteractor<Employee>, CommonInteractor<Employee>>();
            services.AddScoped<ICommonInteractor<Provider>, CommonInteractor<Provider>>();
            services.AddScoped<ICommonInteractor<Purchase>, CommonInteractor<Purchase>>();
        }

    }
}
