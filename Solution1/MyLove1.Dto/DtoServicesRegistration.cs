
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace MyLove1.Dto
{
    public static class DtoServicesRegistration
    {
        public static IServiceCollection ConfigureDtoServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
           services.AddMediatR(assembly);

            return services;
        }
    }

}
