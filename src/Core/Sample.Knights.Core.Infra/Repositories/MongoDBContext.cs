using MongoDB.Driver;
using Sample.Knights.Core.Domain.Interfaces.Infra.Services;
using Sample.Knights.Core.Domain.Interfaces.Repositories;
using Sample.Utils.Extensions;

namespace Sample.Knights.Core.Infra.Repositories;

public class MongoDBContext(IMongoDBService mongoDBService) : IMongoDBContext
{
    public IMongoCollection<TEntity> Set<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;
        var collectionByType = mongoDBService.CollectionMapping.FirstOrDefault(x => x.Key == type);
        if (collectionByType.IsNull() || collectionByType.Value.IsNullorEmpty())
            throw new ArgumentException($"Cannot find collection of type {typeof(TEntity)}");

        return mongoDBService.Database.GetCollection<TEntity>(collectionByType.Value);
    }

    public void Dispose()
    {
        mongoDBService.Dispose();

        GC.SuppressFinalize(this);
    }
}
