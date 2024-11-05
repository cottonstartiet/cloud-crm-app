using AutoMapper;
using CrmApi.Contracts;
using CrmApi.Models;

namespace CrmApi.Mappers;

public class ContactMapperProfile : Profile
{
    public ContactMapperProfile()
    {
        _ = CreateMap<CreateContactRequest, Contact>();
        _ = CreateMap<Contact, ContactResponse>();
    }
}
