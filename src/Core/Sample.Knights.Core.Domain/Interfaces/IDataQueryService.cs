using MongoDB.Driver.Linq;
using Sample.Knights.Core.Domain.Entities;

namespace Sample.Knights.Core.Domain.Interfaces;

public interface IDataQueryService<T> : IDisposable where T : Identifier
{
    IMongoQueryable<T> BaseQuery();
    IMongoQueryable<T> ById(string id);
    IMongoQueryable<T> ByIds(IEnumerable<string> ids);
    Task<bool> Exists(string id);
    Task<T> GetById(string id);
}
