using CrmApi.Contracts;
using CrmApi.Models;
using CrmApi.Storage.Entities;
using Riok.Mapperly.Abstractions;

namespace CrmApi.Mappers
{
    [Mapper]
    public partial class ContactMapper
    {
        [MapperIgnoreTarget(nameof(Contact.Id))]
        public partial Contact CreateContactRequestToContacMapper(CreateContactRequest createContactRequest);

        public partial ContactResponse ConvertContactToContactResponse(Contact contact);

        [MapperIgnoreSource(nameof(ContactDao.Pk))]
        public partial Contact ConvertContactDaoToContact(ContactDao contactDao);

        [MapProperty(nameof(Contact.Id), nameof(ContactDao.Pk))]
        public partial ContactDao ConvertContactToContactDao(Contact contact);
    }
}
