using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dot6.MongoDb.API.CRUD.Collections;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("Bar")]
    public string Bar { get; set; }

   
}