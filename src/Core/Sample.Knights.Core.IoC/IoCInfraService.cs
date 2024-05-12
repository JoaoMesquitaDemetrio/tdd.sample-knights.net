using Microsoft.Extensions.DependencyInjection;
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
            var options = service.GetService<AppSettings>();           
            
            return new MongoDBService(
                options.ConnectionStrings.MongoDBConnection, 
                options.ConnectionStrings.MongoDBDatabase,
                options.MongoEntityCollectionMapping
            ) as IMongoDBService;
        });
    }
}
