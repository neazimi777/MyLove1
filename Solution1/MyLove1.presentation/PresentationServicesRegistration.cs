using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CPM.Dimension.Presentation;

/// <summary>
///     register all needed services of presentation layer
/// </summary>
public static class PresentationServicesRegistration
{
    /// <summary>
    ///     register all needed services of presentation layer
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigurePresentationServices(this IServiceCollection services)
{
    var assembly = Assembly.GetExecutingAssembly();

    services
        .AddControllers()
        .AddApplicationPart(assembly);

    services.AddLocalization(options => options.ResourcesPath = "Resources");
    services.Configure<RequestLocalizationOptions>(
        options =>
        {
            var supportedCultures = new List<CultureInfo>
            {
                    new CultureInfo("fa-FA")
            };

            options.DefaultRequestCulture = new RequestCulture(culture: "fa-FA", uiCulture: "fa-FA");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

    services.AddSwaggerGen(options =>
    {
        var presentationDocumentationFile = $"{assembly.GetName().Name}.xml";
        var presentationDocumentationFilePath =
            Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);
        options.IncludeXmlComments(presentationDocumentationFilePath);
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1.1",
            Title = "CPM Dimension Management/ Design Attributes / Data entry values  API",
            Description = "An ASP.NET Core Web API for managing CPM Dimension Management/ Design Attributes / Data entry values",
            TermsOfService = new Uri("https://cpm.son.ir/terms"),
            Contact = new OpenApiContact
            {
                Name = "SON Corp.",
                Url = new Uri("https://son.ir/تماس-با-ما/")
            },
            License = new OpenApiLicense
            {
                Name = "License",
                Url = new Uri("https://son.ir/license")
            }
        });
            });
            return services;
    }

}