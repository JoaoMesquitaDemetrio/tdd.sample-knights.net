
using MongoDB.Driver;

namespace Sample.Knights.Core.Domain.Interfaces.Infra.Services;

public interface IMongoDBService : IDisposable
{
    public IMongoDatabase Database { get; }
    public Dictionary<string, string> CollectionMapping { get; }    
}
