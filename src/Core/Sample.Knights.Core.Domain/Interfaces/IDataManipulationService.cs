using Sample.Knights.Core.Domain.Entities;

namespace Sample.Knights.Core.Domain.Interfaces;

public interface IDataManipulationService<T> : IDataQueryService<T>, IDisposable where T : Identifier
{
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
}
