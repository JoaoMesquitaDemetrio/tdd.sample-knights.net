using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Sample.Knights.UI.Api.Components;

namespace Sample.Knights.UI.Api.Extensions;

public static class ExceptionExtensions
{
    internal static void SetupExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var correlationId = context.TraceIdentifier;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var handler = new HandlerException(
                        correlationId,
                        context.Request.Host.Host
                    );

                    var result = handler.ResponseException(contextFeature.Error);
                    context.Response.StatusCode = (int)result.StatusCode;

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(result.Response));
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync("Internal Server Error");
                }
            });
        });
    }
}
