namespace Mint.Application.Options
{
    public class MongoDatabaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;
    }
}
