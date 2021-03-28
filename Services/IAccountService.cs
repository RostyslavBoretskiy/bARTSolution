using bARTSolution.Domain.Infrastructure.Models;
using bARTSolutionWeb.Domain.Services.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAccountsAsync();
        Task<AccountModel> GetAccountAsync(int id);
        Task<AccountModel> GetAccountAsync(string name);
        Task<AccountModel> CreateAccountAsync(AccountViewModel model);
        Task<ResultModel> UpdateAccountAsync(AccountModel model);
        Task<ResultModel> UpsertAccountAsync(AccountModel model);
        Task<ResultModel> DeleteAccountAsync(int id);
        Task<ResultModel> AddContact(string accountName, ContactViewModel contactVM);
    }
}
