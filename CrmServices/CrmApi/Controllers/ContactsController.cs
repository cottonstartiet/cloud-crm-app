using CrmApi.BusinessLogic;
using CrmApi.Contracts;
using CrmApi.Mappers;
using CrmApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(ContactsBusinessLogic contactsBusinessLogic, ContactMapper contactMapper) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<ContactResponse>> CreateContact([FromBody] CreateContactRequest request)
        {
            Contact contact = contactMapper.CreateContactRequestToContacMapper(request);
            Contact result = await contactsBusinessLogic.CreateContactAsync(contact);
            ContactResponse response = contactMapper.ConvertContactToContactResponse(result);
            return CreatedAtAction(nameof(GetContact), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResponse>> GetContact(string id)
        {
            Contact result = await contactsBusinessLogic.GetContactAsync(id);
            ContactResponse response = contactMapper.ConvertContactToContactResponse(result);
            return Ok(response);
        }
    }
}
