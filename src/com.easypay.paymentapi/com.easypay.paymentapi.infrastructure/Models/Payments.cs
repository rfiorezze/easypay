using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace com.easypay.paymentapi.infrastructure.Models
{
    public class Payments
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("CardHolderName")]
        public string CardHolderName { get; set; }

        [BsonElement("Ammount")]
        public decimal Ammount { get; set; }

        [BsonElement("IsApproved")]
        public bool IsApproved { get; set; }

        [BsonElement("TransactionDate")]
        public DateTime TransactionDate { get; set; }

    }
}
