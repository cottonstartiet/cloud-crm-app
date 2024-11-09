using CrmApi.Storage.Entities;
using Microsoft.Azure.Cosmos;

namespace CrmApi.Storage
{
    public class ContactsStore
    {
        private readonly Container contactsContainer;

        public ContactsStore(CosmosDbService cosmosDbService)
        {
            contactsContainer = cosmosDbService.ContactsContainer;
        }

        public async Task<ContactDao> GetItemAsync(string id, string partitionKey)
        {
            ItemResponse<ContactDao> response = await contactsContainer.ReadItemAsync<ContactDao>(id, new PartitionKey(partitionKey));
            return response.Resource;
        }

        public async Task<ContactDao> CreateOrUpdateItemAsync(ContactDao contactDao)
        {
            ItemResponse<ContactDao> response = await contactsContainer.UpsertItemAsync(contactDao, new PartitionKey(contactDao.Id));
            return response.Resource;
        }
    }
}
