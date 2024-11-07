using CrmApi.Contracts;
using CrmApi.Models;
using Riok.Mapperly.Abstractions;

namespace CrmApi.Mappers
{
    [Mapper]
    public partial class ContactMapper
    {
        public partial Contact CreateContactRequestToContacMapper(CreateContactRequest createContactRequest);
        public partial ContactResponse ConvertContactToContactResponse(Contact contact);
    }
}
