using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sample.Knights.UI.Api.Components;

public class HttpInterceptionCorrelation : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var correlationId = Guid.NewGuid();
        context.HttpContext.TraceIdentifier = correlationId.ToString();

        await next();
    }
}
