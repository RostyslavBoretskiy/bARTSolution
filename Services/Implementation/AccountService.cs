using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<AccountModel> CreateAccountAsync(AccountModel model)
        {
            return await accountRepository.CreateAsync(model);
        }

        public async Task<AccountModel> GetAccountAsync(int id)
        {
            return await accountRepository.GetByIdAsync(id);
        }

        public IEnumerable<AccountModel> GetAccounts()
        {
            return accountRepository.GetAll();
        }

        public async Task<ResultModel> UpdateAccountAsync(AccountModel model)
        {
            return await accountRepository.UpdateAsync(model);
        }
    }
}
