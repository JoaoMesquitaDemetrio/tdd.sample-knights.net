using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sample.Knights.Core.Domain.Interfaces.Infra.Services;
using Sample.Knights.Core.Domain.Settings;
using Sample.Knights.Core.Infra.Services;

namespace Sample.Knights.Core.IoC;

internal static class IoCInfraService
{
    public static void ApplyToInfraServices(this IServiceCollection services)
    {
        services.AddScoped(service => 
        {
            var options = service.GetService<IOptionsSnapshot<AppSettings>>();
            
            return new MongoDBService(
                options.Value.ConnectionStrings.MongoDBConnection, 
                options.Value.ConnectionStrings.MongoDBDatabase,
                options.Value.MongoEntityCollectionMapping
            ) as IMongoDBService;
        });
    }
}
