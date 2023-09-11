using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Persistence.DB
{
    public static class DI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DBConnection"];

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("WebAPI"));
            });

            services.AddScoped<IAppDBContext>(provider =>
            {
                return  provider.GetService<AppDBContext>();
            });

            return services;
        }
    }
}
