namespace Mint.Application.Options
{
    public class MongoDatabaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string TransactionCollection { get; set; } = string.Empty;
        public string CategoryCollection { get; set; } = string.Empty;
        public string BudgetCollection { get; set; } = string.Empty;
    }
}
