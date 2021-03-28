using bARTSolution.Domain.Services;
using bARTSolutionWeb.Domain.Services.Models;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace bARTSolution.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Returns all accounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await accountService.GetAccountsAsync());
        }

        /// <summary>
        /// Returns account by id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await accountService.GetAccountAsync(id));
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountViewModel model)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState.Values);

            var result = await accountService.CreateAccountAsync(model);

            if (result == null)
                return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Delete account by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await accountService.DeleteAccountAsync(id);

            if (!result.IsDone)
                return BadRequest();

            return Ok();
        }
    }
}
