using MenuApp.OrderService.EntityFramework.Data;
using MenuApp.OrderService.EntityFramework.Repository;
using MenuApp.OrderService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MenuApp.OrderService.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseNpgsql(connectionString);
            });

            services.AddTransient<IForecastRepository, ForecastRepository>();
            
            return services;
        }
    }
}