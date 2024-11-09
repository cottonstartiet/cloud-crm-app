using CrmApi.Utils;
using Microsoft.Azure.Cosmos;

namespace CrmApi.Storage
{
    public class CosmosDbService
    {
        private readonly CosmosClient cosmosClient;
        private readonly Database crmDatabase;
        public Container ContactsContainer { get; set; }

        public CosmosDbService(string connectionString, string databaseName, CosmosDbConfig config)
        {
            cosmosClient = new CosmosClient(connectionString);
            crmDatabase = cosmosClient.GetDatabase(config.DatabaseName);
            ContactsContainer = crmDatabase.GetContainer("Contacts");
        }
    }
}
