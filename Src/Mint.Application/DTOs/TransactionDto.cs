namespace Mint.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for a financial transaction.
    /// </summary>
    public class TransactionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; }
    }
}