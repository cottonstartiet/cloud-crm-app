namespace CrmApi.Configurations
{
    public class CosmosDbConfig
    {
        public const string ConfigName = "CosmosDbConfig";

        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
    }
}
