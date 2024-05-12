namespace Sample.Knights.Core.Application.DataTransferObjects.HttpResponse;

public record ResponseErrorAggregate(IList<ResponseErrorContent> Errors = default)
{
    public ResponseErrorAggregate() : this(new List<ResponseErrorContent>()) { }
}
