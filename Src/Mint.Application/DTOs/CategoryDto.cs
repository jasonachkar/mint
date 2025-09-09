namespace Mint.Application.DTOs
{
    public record CategoryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public int SetAmount { get; init; } // Budgeted amount for this category
    }
}