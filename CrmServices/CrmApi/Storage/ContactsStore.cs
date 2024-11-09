using Microsoft.Azure.Cosmos;

namespace CrmApi.Storage
{
    public class ContactsStore()
    {
        private readonly CosmosClient cosmosClient;
        private readonly Container contactsContainer;

        public ContactsStore(CosmosDbService cosmosDbService)
        {
            cosmosClient = cosmosDbService.GetClient();
            contactsContainer = cosmos
        }
        public async Task<Contact> CreateItemAsync(Contact contact)
        {
            return await contactsContainer..contact;
        }
    }
}
