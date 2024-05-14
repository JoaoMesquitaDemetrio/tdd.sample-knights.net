using DO = Sample.Knights.Core.Domain.Entities;

namespace Sample.Knights.Core.Application.DataTransferObjects;

public record Identifier<T>(Guid Id) : BaseModel<T> where T : DO.BaseEntity
{
    public override T TransferTo()
        => new DO.BaseEntity { Id = Id.ToString() } as T;

    public override void UpdateEntity(T entity)
        => entity.Id = Id.ToString();
}
