using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mint.Domain.Models
{
    public class Transaction
    {
        [BsonId]
        // Explicitly specify the GUID representation for this property
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; }

        public Transaction()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}