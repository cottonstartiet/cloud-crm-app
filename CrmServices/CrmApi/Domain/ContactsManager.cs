using CrmApi.Mappers;
using CrmApi.Models;
using CrmApi.Storage;

namespace CrmApi.Domain;

public class ContactsManager(ContactsStore contactsStore, ContactMapper contactMapper)
{
    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        Storage.Entities.ContactDao contactDao = contactMapper.ConvertContactToContactDao(contact);
        _ = await contactsStore.CreateOrUpdateItemAsync(contactDao);
        return contactMapper.ConvertContactDaoToContact(contactDao);
    }

    internal async Task<Contact?> GetContactByIdAsync(string id)
    {
        Storage.Entities.ContactDao? contactDao = await contactsStore.GetItemAsync(id, id);
        return contactDao == null ? null : contactMapper.ConvertContactDaoToContact(contactDao);
    }
}
