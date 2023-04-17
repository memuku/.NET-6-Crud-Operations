using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("Bar")]
        public string Bar { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [BsonElement("TcNO")]
        public object TcNO { get; set; }
        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("UserName")]
        public string Username { get; set; }

    }
}