namespace Sample.Knights.Core.Application.DataTransferObjects.HttpResponse;

public record ResponseErrorContent(int Code, string Message)
{ 
    public override string ToString()
        => $"{Code} - {Message}";
}
