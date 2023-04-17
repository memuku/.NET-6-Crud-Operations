using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public class Photo
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }
        [BsonElement("Url")]
        public string Url { get; set; }
    }
}
