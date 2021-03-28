using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Services;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace bARTSolution.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        /// <summary>
        /// Returns all contacts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await contactService.GetContactsAsync());
        }

        /// <summary>
        /// Returns contact by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            return Ok(await contactService.GetContactByEmailAsync(email));
        }

        /// <summary>
        /// Create new contact.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await contactService.CreateContactAsync(model);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        /// <summary>
        /// Delete contact.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await contactService.DeleteContactAsync(id));
        }
    }
}
