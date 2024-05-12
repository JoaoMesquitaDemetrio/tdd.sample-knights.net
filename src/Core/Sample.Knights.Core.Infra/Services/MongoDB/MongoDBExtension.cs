using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace Sample.Knights.Core.Infra.Services.MongoDB;

public static class MongoDBExtension
{
    public static void RegisterBsonSerializer()
    {
        BsonSerializer.RegisterSerializer(DateTimeSerializer.LocalInstance);
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

        var appEntitiesToRegister = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(t => t.GetTypes())
            .Where(t => t.IsClass && t.GetCustomAttributes(typeof(BsonKnownTypesAttribute), false).Any())?.ToList();

        foreach (var appEntity in appEntitiesToRegister)
        {
            var bsonKnownTypesAttribute = appEntity.GetCustomAttributes(typeof(BsonKnownTypesAttribute), false).FirstOrDefault() as BsonKnownTypesAttribute;
            var knownTypes = bsonKnownTypesAttribute.KnownTypes;
            var classMap = BsonClassMap.LookupClassMap(appEntity);

            foreach (var knownType in knownTypes) 
            {
                var knownTypeClassMap = BsonClassMap.LookupClassMap(knownType);
            }
        }
    }
}
