using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyLove1.DomainService
{
    public static class DomainServiceServicesRegistration
    {
        public static IServiceCollection ConfigureDomainServiceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
