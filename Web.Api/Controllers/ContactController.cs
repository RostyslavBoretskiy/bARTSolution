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
            return new OkObjectResult(await contactService.GetContactsAsync());
        }

        /// <summary>
        /// Returns contact by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            return new OkObjectResult(await contactService.GetContactByEmailAsync(email));
        }

        /// <summary>
        /// Create new contact.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactModel model)
        {
            return new OkObjectResult(await contactService.CreateContactAsync(model));
        }

        /// <summary>
        /// Update contact.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactModel model)
        {
            return new OkObjectResult(await contactService.UpdateContactAsync(model));
        }

        /// <summary>
        /// Delete contact.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return new OkObjectResult(await contactService.DeleteContactAsync(id));
        }
    }
}
