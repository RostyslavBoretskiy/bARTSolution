using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Services;
using bARTSolutionWeb.Domain.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bARTSolution.Web.Api.Controllers
{
    [Route("api/[controller]")]
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
            return new OkObjectResult(await accountService.GetAccountsAsync());
        }

        /// <summary>
        /// Returns account by id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new OkObjectResult(await accountService.GetAccountAsync(id));
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountModel model)
        {
            return new OkObjectResult(await accountService.CreateAccountAsync(model));
        }

        /// <summary>
        /// Update account.
        /// </summary>
        /// <param name="model"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AccountModel model)
        {
            return new OkObjectResult(await accountService.UpdateAccountAsync(model));
        }

        /// <summary>
        /// Delete account by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return new OkObjectResult(await accountService.DeleteAccountAsync(id));
        }
    }
}
