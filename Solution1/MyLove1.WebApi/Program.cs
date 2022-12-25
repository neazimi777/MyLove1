
using CPM.Dimension.Presentation;
using MyLove1.DomainService;
using MyLove1.Dto;
using MyLove1.Persistence;
using NLog;

namespace CPM.Dimension.WebApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //TODO configure logger.

        ConfigureDependencies(builder); // Add services to the DI container.
        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen(); //TODO revise!
        ConfigureCors(builder);

        var app = builder.Build();

        ConfigureHttpRequestPipeline(app);
        //TODO if needed! - await ApplyMigrations(webHost.Services);

        await app.RunAsync();
    }
    private static Logger logger = LogManager.GetCurrentClassLogger();

    private static void ConfigureCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(o =>
        {
            o.AddPolicy("CorsPolicy",
                corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin() //TODO change it with more safe command
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    private static void ConfigureDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        ConfigureServices(builder);

       // builder.Services.AddTransient<ExceptionHandlingMiddleware>();
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.ConfigurePresentationServices();
        builder.Services.ConfigurePersistenceServices(builder.Configuration);
        builder.Services.ConfigureDomainServiceServices(builder.Configuration);
        builder.Services.ConfigureDtoServices();
    }

    private static void ConfigureHttpRequestPipeline(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

       // app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();
        //TODO it is from Code-Maze - onion arch. // should it be used? // app.UseRouting();
        //app.UseStaticFiles();

        //if authentication service is added // app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("CorsPolicy");

        app.MapControllers();
    }

    // ReSharper disable once UnusedMember.Local
    private static async Task ApplyMigrations(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope(); // do all migrations or none of them! create a transaction scope - MHA

        await using var dbContext = scope.ServiceProvider.GetRequiredService<MyLove1DBContext>();
 
    }
}