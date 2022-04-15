
namespace Storage.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using Storage.Models.Enums;

    [BsonIgnoreExtraElements]
    public class CarrierRate
    {
        public int CarrierId { get; set; }
        public ChargeCode Charges { get; set; }
    }
}
