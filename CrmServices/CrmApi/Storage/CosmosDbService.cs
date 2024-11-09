using CrmApi.Configurations;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace CrmApi.Storage
{
    public class CosmosDbService
    {
        private readonly CosmosClient cosmosClient;
        private readonly Database crmDatabase;

        private const string CONTACTS_CONTAINER = "Contacts";

        public Container ContactsContainer { get; set; }

        public CosmosDbService(IOptions<CosmosDbConfig> config)
        {
            CosmosClientOptions cosmosClientOptions = new()
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            };
            cosmosClient = new CosmosClient(config.Value.ConnectionString, cosmosClientOptions);
            crmDatabase = cosmosClient.GetDatabase(config.Value.DatabaseName);
            ContactsContainer = crmDatabase.GetContainer(CONTACTS_CONTAINER);
        }
    }
}
