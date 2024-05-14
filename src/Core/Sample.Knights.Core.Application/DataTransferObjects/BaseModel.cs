namespace Sample.Knights.Core.Application.DataTransferObjects;

public abstract record BaseModel<T> where T : class
{
    public abstract T TransferTo();
    public abstract void UpdateEntity(T entity);
}
