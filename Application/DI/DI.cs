using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Persistence.DB
{
    public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
