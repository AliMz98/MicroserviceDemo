using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Domain.Entities
{
    public class Order
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("customer_id"), BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid CustomerId { get; set; }
        [BsonElement("order_on"), BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderedOn { get; set; }
        [BsonElement("order_details")]
        public List<OrderDetail> Details { get; set; }
    }
}
