using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sample.Knights.Core.Domain.Entities;
using Sample.Knights.Core.Domain.Interfaces;
using Sample.Knights.Core.Domain.Interfaces.Repositories;

namespace Sample.Knights.Core.Domain.Services;

public class DataQueryService<T>(IMongoDBContext context) : IDataQueryService<T> where T : Identifier
{
    public IMongoQueryable<T> BaseQuery()
        => context.Set<T>().AsQueryable() ;

    public IMongoQueryable<T> ById(string id)
        => BaseQuery().Where(x => x.Id == id);

    public IMongoQueryable<T> ByIds(IEnumerable<string> ids)
        => BaseQuery().Where(x => ids.Contains(x.Id));

    public async Task<bool> Exists(string id)
        => await BaseQuery().AnyAsync(x => x.Id == id);

    public async Task<T> GetById(string id)
        => await BaseQuery().FirstAsync(x => x.Id == id);

    public void Dispose()
    {
        context?.Dispose();

        GC.SuppressFinalize(this);
    }
}
