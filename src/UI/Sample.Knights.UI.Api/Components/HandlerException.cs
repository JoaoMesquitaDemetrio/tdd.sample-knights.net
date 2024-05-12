using System.Net;
using Sample.Knights.Core.Application.DataTransferObjects.HttpResponse;

namespace Sample.Knights.UI.Api.Components;

public class HandlerException
{
    public string CorrelationId { get; set; }
    
    public string IpAddress { get; set; }

    public HandlerException() { }

    public HandlerException(string correlationId, string ipAddress)
    {
        CorrelationId = correlationId;
        IpAddress = ipAddress;
    }

    public ExceptionResult ResponseException(Exception exception)
    {
        switch (exception)
        {
            case NotImplementedException _:
                return ResponseException(HttpStatusCode.Unauthorized, "Sem permissão para esta operação");

            case AggregateException _:
                var aggrEx = (AggregateException)exception;
                return ResponseException(HttpStatusCode.BadRequest, aggrEx.InnerExceptions.ToArray());

            case ArgumentException _:
                return ResponseException(HttpStatusCode.BadRequest, exception.Message);

            case TaskCanceledException _:
            case OperationCanceledException _:
                return ResponseException(HttpStatusCode.BadRequest, "Operação cancelada pelo usuário.");

            default:
                return ResponseException(HttpStatusCode.InternalServerError, exception.Message);
        }
    }

    public ExceptionResult ResponseException(HttpStatusCode statusCode, string message)
    {
        var error = new ResponseErrorContent((int)statusCode, message);
        var responseError = new ResponseError(error);
        
        return new ExceptionResult(statusCode, responseError);
    }
    
    public ExceptionResult ResponseException(HttpStatusCode statusCode, Exception[] exceptions)
    {
        var responseError = new ResponseErrorAggregate();
        foreach (var exception in exceptions)
            responseError.Errors.Add(new ResponseErrorContent((int)statusCode, exception.Message));
        
        return new ExceptionResult(statusCode, responseError);
    }
}

