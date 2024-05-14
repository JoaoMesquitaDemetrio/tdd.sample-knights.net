using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Knights.UI.Api.Controllers;

public class BaseController : ControllerBase
{
    private object CreateResponse(HttpStatusCode statusCode, object value)
    {
        HttpContext.Response.StatusCode = (int)statusCode;
        return value;
    }

    internal object ResponseResult()
        => CreateResponse(HttpStatusCode.OK, new { result = "success" });
    
    internal object ResponseResult(object value, bool notFoundIfNull = false)
    {
        if (notFoundIfNull && value == null)
            return CreateResponse(HttpStatusCode.NotFound, value);

        if (value == null)
            value = new { };

        return CreateResponse(HttpStatusCode.OK, value);
    }

    internal object ResponseResult(HttpStatusCode statusCode, object value)
        => CreateResponse(statusCode, value);
    
    internal void ExposeFileNameHeader()
        => HttpContext.Response.Headers.Append("Access-Control-Expose-Headers", "Content-Disposition");
}

