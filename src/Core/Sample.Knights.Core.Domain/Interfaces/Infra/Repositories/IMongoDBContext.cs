using MongoDB.Driver;

namespace Sample.Knights.Core.Domain.Interfaces.Repositories;

public interface IMongoDBContext
{
    IMongoCollection<TEntity> Set<TEntity>() where TEntity : class;
}
