using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace com.easypay.be.infrastructure.Models
{
    public class Clients
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Agency")]
        public string Agency { get; set; }

        [BsonElement("Account")]
        public string Account { get; set; }

        [BsonElement("Bank")]
        public string Bank { get; set; }
    }
}
