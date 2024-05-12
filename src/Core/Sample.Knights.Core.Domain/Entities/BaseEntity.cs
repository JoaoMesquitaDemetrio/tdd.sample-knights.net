using MongoDB.Bson.Serialization.Attributes;

namespace Sample.Knights.Core.Domain.Entities;

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(BaseEntity))]
public class BaseEntity : Identifier
{
    public bool Removed { get; set; }
}
