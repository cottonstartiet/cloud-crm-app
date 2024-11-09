using Microsoft.Azure.Cosmos;

namespace CrmApi.Storage
{
    public class CosmosDbService
    {
        private readonly CosmosClient cosmosClient;
        private readonly Database crmDatabase;

        public CosmosDbService(string connectionString, string databaseName)
        {
            cosmosClient = new CosmosClient(connectionString);
            crmDatabase = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
        }

        public Database GetDatbase()
        {
            return crmDatabase;
        }
    }
}
