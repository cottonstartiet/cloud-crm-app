using CrmApi.Models;
using CrmApi.Storage;

namespace CrmApi.Domain;

public class ContactsManager(ContactsStore contactsStore)
{
    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        return await contactsStore.CreateOrUpdateItemAsync(contact);
    }

    internal async Task<Contact> GetContactByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}
