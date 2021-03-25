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
        Task<AccountModel> CreateAccountAsync(CreateAccountModel model);
        Task<ResultModel> UpdateAccountAsync(AccountModel model);
    }
}
