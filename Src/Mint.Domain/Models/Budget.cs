namespace Mint.Domain.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Income { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}