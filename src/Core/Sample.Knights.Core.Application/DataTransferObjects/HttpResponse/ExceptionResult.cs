using System.Net;

namespace Sample.Knights.Core.Application.DataTransferObjects.HttpResponse;

public record ExceptionResult(HttpStatusCode StatusCode, object Response) { }
