using CrmApi.Models;
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

        public async Task<Contact> GetItemAsync(string id)
        {
            return await contactsContainer.ReadItemAsync<Contact>(id, new PartitionKey(id));
        }

        public async Task<Contact> CreateOrUpdateItemAsync(Contact contact)
        {
            return await contactsContainer.UpsertItemAsync(contact, new PartitionKey(contact.Id));
        }
    }
}
