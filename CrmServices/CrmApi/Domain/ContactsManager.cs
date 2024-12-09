using CrmApi.Mappers;
using CrmApi.Models;
using CrmApi.Storage;
using CrmApi.Storage.Entities;

namespace CrmApi.Domain;

public class ContactsManager(ContactsStore contactsStore, ContactMapper contactMapper)
{
    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        ContactDao contactDao = contactMapper.ConvertContactToContactDao(contact);
        _ = await contactsStore.CreateOrUpdateItemAsync(contactDao);
        return contactMapper.ConvertContactDaoToContact(contactDao);
    }

    internal async Task<Contact?> GetContactByIdAsync(string id)
    {
        ContactDao? contactDao = await contactsStore.GetItemAsync(id, id);
        return contactDao == null ? null : contactMapper.ConvertContactDaoToContact(contactDao);
    }

    internal async Task<IList<Contact>> GetContacts(int limit)
    {
        IList<Contact> contacts = [];

        IList<ContactDao> contactsDtoList = await contactsStore.GetContactsBatch(limit);

        foreach (ContactDao contactDao in contactsDtoList)
        {
            contacts.Add(contactMapper.ConvertContactDaoToContact(contactDao));
        }

        return contacts;
    }
}
