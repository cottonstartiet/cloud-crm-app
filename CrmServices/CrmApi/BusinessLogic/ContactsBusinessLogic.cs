using CrmApi.Models;

namespace CrmApi.BusinessLogic;

public class ContactsBusinessLogic
{
    internal async Task<Contact> CreateContactAsync(Contact contact)
    {
        return await Task.FromResult(new Contact { Id = Guid.NewGuid().ToString(), FirstName = contact.FirstName, LastName = contact.LastName });
    }

    internal async Task<Contact> GetContactAsync(string id)
    {
        return await Task.FromResult(new Contact { Id = id, FirstName = "John", LastName = "Doe" });
    }
}
