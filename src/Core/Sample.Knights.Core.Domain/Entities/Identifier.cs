using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sample.Knights.Core.Domain.Entities;

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(Identifier))]
public class Identifier
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public Identifier()
    {
        Id = ObjectId.GenerateNewId().ToString();
    }
}
