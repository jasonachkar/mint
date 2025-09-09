namespace Mint.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // These two fields might be redundant and need to be removed later
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int SetAmount { get; set; } // Budgeted amount for this category

        public Category()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public Category(string name, string description, int setAmount) : this()
        {
            Name = name;
            Description = description;
            SetAmount = setAmount;
        }
    }
}