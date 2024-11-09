using CrmApi.Storage;

namespace CrmApi.Domain;

public class ContactsManager(ContactsStore contactsStore)
{
    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        return await contactsStore.CreateItemAsync(contact);
    }
}
