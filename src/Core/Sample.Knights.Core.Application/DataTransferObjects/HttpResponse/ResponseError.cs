namespace Sample.Knights.Core.Application.DataTransferObjects.HttpResponse;

public record ResponseError(ResponseErrorContent Error)
{
    public override string ToString()
        => Error.ToString();
}
