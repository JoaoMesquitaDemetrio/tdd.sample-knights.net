using Microsoft.Extensions.DependencyInjection;
using Sample.Knights.Core.Domain.Interfaces.Repositories;
using Sample.Knights.Core.Infra.Repositories;

namespace Sample.Knights.Core.IoC;

internal static class IoCInfraRepository
{
    public static void ApplyToInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMongoDBContext, MongoDBContext>();
    }
}
