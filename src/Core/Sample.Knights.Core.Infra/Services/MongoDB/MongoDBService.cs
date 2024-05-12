using MongoDB.Driver;
using Sample.Knights.Core.Domain.Interfaces.Infra.Services;

namespace Sample.Knights.Core.Infra.Services;

public class MongoDBService : IMongoDBService
{
    public IMongoDatabase Database { get; private set; }
    public Dictionary<string, string> CollectionMapping { get; private set; }
    
    public MongoDBService(
        string connectionString, 
        string databaseName,
        Dictionary<string, string> entityCollectionMapping)
    {
        var client = new MongoClient(connectionString);
        Database = client.GetDatabase(databaseName);
        CollectionMapping = entityCollectionMapping;
    }
    
    public void Dispose() 
    {
        Database.Client.Cluster.Dispose();
        
        GC.SuppressFinalize(this);
    }
}
