using AutoMapper;
using CrmApi.BusinessLogic;
using CrmApi.Contracts;
using CrmApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ContactsBusinessLogic contactsBusinessLogic;

        public ContactsController(ContactsBusinessLogic contactsBusinessLogic, IMapper mapper)
        {
            this.contactsBusinessLogic = contactsBusinessLogic;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ContactResponse>> CreateContact([FromBody] CreateContactRequest request)
        {
            Contact contact = mapper.Map<Contact>(request);
            Contact result = await contactsBusinessLogic.CreateContactAsync(contact);
            ContactResponse response = mapper.Map<ContactResponse>(result);
            return CreatedAtAction(nameof(GetContact), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResponse>> GetContact(string id)
        {
            Contact result = await contactsBusinessLogic.GetContactAsync(id);
            ContactResponse response = mapper.Map<ContactResponse>(result);
            return Ok(response);
        }
    }
}
