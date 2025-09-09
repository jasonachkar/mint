using MongoDB.Bson.Serialization.Attributes;

namespace Mint.Domain.Models
{
    public class Budget
    {
        [BsonId]
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Income { get; set; }
        public decimal Expense { get; set; } // Total Expenses: Sum of all expenses in one month
        public decimal Balance { get; set; } // Balance: Income - Expense
        public DateTime Month { get; set; } // The month this budget is for
        public DateTime CreatedAt { get; set; }
        public List<Category> Categories { get; set; } // Associated categories for this budget
        public List<Transaction> Transactions { get; set; } // Associated transactions for this budget
        public Budget()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Categories = [];
            Transactions = [];
        }
    }
}