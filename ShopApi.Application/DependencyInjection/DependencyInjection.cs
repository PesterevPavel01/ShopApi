
using Microsoft.Extensions.DependencyInjection;
using ShopApi.Application.Services;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            InitServices(services);
        }

        private static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<ICommonService<EmployeeDto,int>, EmployeeService>();
        }
    }
}
