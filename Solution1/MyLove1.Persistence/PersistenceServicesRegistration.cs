using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyLove1.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            //https://stackoverflow.com/questions/48443567/adddbcontext-or-adddbcontextpool
            services.AddDbContextPool<MyLoveDBContex>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CPMDB")));

            return services;
        }
    }
}
