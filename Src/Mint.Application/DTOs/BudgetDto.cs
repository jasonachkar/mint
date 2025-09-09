
namespace Mint.Application.DTOs
{
    public record BudgetDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public decimal Income { get; init; }
        public decimal Expense { get; init; } // Total Expenses: Sum of all expenses in one month
        public decimal Balance { get; init; } // Balance: Income - Expense
        public DateTime Month { get; init; } // The month this budget is for
        public DateTime CreatedAt { get; init; }
    }
}