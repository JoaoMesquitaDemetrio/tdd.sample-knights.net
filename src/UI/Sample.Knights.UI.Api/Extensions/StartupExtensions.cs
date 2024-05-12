using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Sample.Knights.Core.Domain.Settings;
using Sample.Knights.Core.IoC;
using Sample.Knights.Core.Infra.Repositories;
using Sample.Knights.Core.Domain.Interfaces.Repositories;
using Sample.Knights.UI.Api.Components;

namespace Sample.Knights.UI.Api.Extensions;

public static class StartupExtensions
{
    internal static void SetupSettings(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<AppSettings>(configuration);
    
    internal static void SetupIoC(this IServiceCollection services)
    {
        services.ApplyIoCSetup();
        services.AddMemoryCache(opt => opt.ExpirationScanFrequency = TimeSpan.FromMinutes(5));
    }

    internal static void SetupRepositories(this IServiceCollection services)
        => services.AddScoped<IMongoDBContext, MongoDBContext>();

    internal static void SetupGlobalRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        => opts.Conventions.Insert(0, new RouteConvention(routeAttribute));
}
