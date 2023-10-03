using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Domain.Entities
{
    public class OrderDetail
    {
        [BsonElement("product.id"), BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid ProductID { get; set; }
        [BsonElement("quantity"), BsonRepresentation(BsonType.Int32)]
        public int Quantity { get; set; }
    }
}
