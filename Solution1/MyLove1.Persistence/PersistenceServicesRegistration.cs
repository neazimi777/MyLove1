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
            ////https://stackoverflow.com/questions/48443567/adddbcontext-or-adddbcontextpool
            //services.AddDbContextPool<MyLove1DBContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("CPMDB")));

            var connectionString = configuration["ConnectionStrings:PostgreConnectionString"];
            services.AddDbContext<MyLove1DBContext>(options => options.UseNpgsql(configuration.GetConnectionString(connectionString)));
        
            return services;
        }
    }
}
