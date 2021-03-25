using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;
using bARTSolutionWeb.Domain.Services;
using bARTSolutionWeb.Domain.Services.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IContactService contactService;

        public AccountService(IAccountRepository accountRepository, IContactService contactService)
        {
            this.accountRepository = accountRepository;
            this.contactService = contactService;
        }

        public async Task<AccountModel> CreateAccountAsync(CreateAccountModel model)
        {
            if (model.ContactEmails.Count() < 1)
                return null;

            var contacts = await contactService.GetContactByEmailsAsync(model.ContactEmails);
            var newAccount = new AccountModel() { Contacts = contacts, IncidentName = model.IncidentName, Name = model.Name };

            return await accountRepository.CreateAsync(newAccount);
        }

        public async Task<AccountModel> GetAccountAsync(int id)
        {
            return await accountRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<AccountModel>> GetAccountsAsync()
        {
            return await accountRepository.GetAllAsync();
        }

        public async Task<ResultModel> UpdateAccountAsync(AccountModel model)
        {
            return await accountRepository.UpdateAsync(model);
        }
    }
}
