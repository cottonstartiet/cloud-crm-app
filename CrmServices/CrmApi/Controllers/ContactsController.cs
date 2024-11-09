using CrmApi.BusinessLogic;
using CrmApi.Contracts;
using CrmApi.Mappers;
using CrmApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(ContactsBusinessLogic contactsBusinessLogic, ContactMapper contactMapper, ILogger<ContactsController> logger) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<ContactResponse>> CreateContact([FromBody] CreateContactRequest request)
        {
            Contact contact = contactMapper.CreateContactRequestToContacMapper(request);
            contact.Id = Guid.NewGuid().ToString();
            Contact result = await contactsBusinessLogic.CreateContactAsync(contact);
            ContactResponse response = contactMapper.ConvertContactToContactResponse(result);
            logger.LogInformation("Contact created with id {id}", response.Id);

            return CreatedAtAction(nameof(GetContact), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResponse>> GetContact(string id)
        {
            Contact? contact = await contactsBusinessLogic.GetContactAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            ContactResponse response = contactMapper.ConvertContactToContactResponse(contact);
            return Ok(response);
        }
    }
}
