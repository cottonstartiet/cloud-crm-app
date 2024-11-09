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

        public async Task<ContactDao> GetItemAsync(string id)
        {
            return await contactsContainer.ReadItemAsync<ContactDao>(id, new PartitionKey(id));
        }

        public async Task<ContactDao> CreateOrUpdateItemAsync(ContactDao contactDao)
        {
            ItemResponse<ContactDao> response = await contactsContainer.UpsertItemAsync(contactDao, new PartitionKey(contactDao.Id));
            return response.Resource;
        }
    }
}
