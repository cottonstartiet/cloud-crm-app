using CrmApi.Domain;
using CrmApi.Models;

namespace CrmApi.BusinessLogic;

public class ContactsBusinessLogic(ContactsManager contactsManager)
{
    internal async Task<Contact> CreateContactAsync(Contact contact)
    {
        return await contactsManager.CreateContactAsync(contact);
    }
}
