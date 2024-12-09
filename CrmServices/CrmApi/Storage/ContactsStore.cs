using CrmApi.Storage.Entities;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace CrmApi.Storage
{
    public class ContactsStore
    {
        private readonly Container contactsContainer;

        public ContactsStore(CosmosDbService cosmosDbService)
        {
            contactsContainer = cosmosDbService.ContactsContainer;
        }

        public async Task<ContactDao?> GetItemAsync(string id, string partitionKey)
        {
            try
            {
                ItemResponse<ContactDao> response = await contactsContainer.ReadItemAsync<ContactDao>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactDao> CreateOrUpdateItemAsync(ContactDao contactDao)
        {
            ItemResponse<ContactDao> response = await contactsContainer.UpsertItemAsync(contactDao, new PartitionKey(contactDao.Id));
            return response.Resource;
        }

        internal async Task<IList<ContactDao>> GetContactsBatch(int limit)
        {
            string query = "select * from contacts c";
            QueryDefinition queryDefinition = new(query);
            using FeedIterator<ContactDao> feed = contactsContainer.GetItemQueryIterator<ContactDao>(
                queryDefinition: queryDefinition,
                requestOptions: new QueryRequestOptions() { MaxItemCount = limit }
            );

            List<ContactDao> results = new(limit);

            while (feed.HasMoreResults)
            {
                FeedResponse<ContactDao> response = await feed.ReadNextAsync();

                foreach (ContactDao item in response.Resource)
                {
                    results.Add(item);
                }
            }

            return results;

        }
    }
}
