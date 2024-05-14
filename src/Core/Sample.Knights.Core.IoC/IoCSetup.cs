using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Sample.Utils.Extensions;
using APP = Sample.Knights.Core.Application.DataTransferObjects;
using DOM = Sample.Knights.Core.Domain.Entities;

namespace Sample.Knights.Core.IoC;

public static class IoCSetup
{
    public static void ApplyIoCSetup(this IServiceCollection services)
    {
        services.ApplyToFrameworkServices();
        services.ApplyToInfraServices();
        services.ApplyToInfraRepositories();
    }

    internal static void ApplyToFrameworkServices(this IServiceCollection services)
    {
        static void HandlerInterface(IServiceCollection services, IEnumerable<TypeInfo> assemblyInterfaces, IEnumerable<TypeInfo> assemblyServices)
        {
            foreach (var appInterface in assemblyInterfaces.GetValueOrDefault())
            {
                var appService = assemblyServices?
                    .Where(s => !s.IsAbstract && !s.IsSealed && s.IsClass)
                    .FirstOrDefault(s => s.ImplementedInterfaces.Contains(appInterface));

                if (appService == null)
                    continue;

                services.AddScoped(appInterface, appService.AsType());
            }
        }
        
        var appServices = Assembly.GetAssembly(typeof(APP.HttpResponse.ResponseError))?.DefinedTypes;
        var appInterfaces = appServices?.Where(t => t.IsInterface)?.ToList();
        HandlerInterface(services, appInterfaces.GetValueOrDefault(), appServices.GetValueOrDefault());

        var domainTypes = Assembly.GetAssembly(typeof(DOM.Identifier))?.DefinedTypes;
        var serviceInterfaces = domainTypes?.Where(t => t.IsInterface)?.ToList();
        HandlerInterface(services, serviceInterfaces.GetValueOrDefault(), domainTypes.GetValueOrDefault());
    }
}
