using Mint.Domain.Models;

namespace Mint.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for a financial transaction.
    /// </summary>
    public record TransactionDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public decimal Amount { get; init; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; init; }

        public Category Category { get; init; }
    }
}