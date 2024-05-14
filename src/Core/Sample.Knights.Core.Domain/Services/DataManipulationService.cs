using MongoDB.Driver;
using Sample.Knights.Core.Domain.Entities;
using Sample.Knights.Core.Domain.Interfaces;
using Sample.Knights.Core.Domain.Interfaces.Repositories;

namespace Sample.Knights.Core.Domain.Services;

public abstract class DataManipulationService<T>(IMongoDBContext context) : DataQueryService<T>(context), IDataManipulationService<T>, IDataQueryService<T> where T : Identifier
{
    private FilterDefinition<T> GetFilter(string id)
        => Builders<T>.Filter.Eq(x => x.Id, id);

    public async Task Delete(Guid id)
    {
        var filter = GetFilter(id.ToString());
        await context.Set<T>().DeleteOneAsync(filter);
    }

    public async Task Insert(T entity)
        => await context.Set<T>().InsertOneAsync(entity);

    public async Task Update(T entity) 
    {
        var filter = GetFilter(entity.Id);
        await context.Set<T>().ReplaceOneAsync(filter, entity);
    }
}
