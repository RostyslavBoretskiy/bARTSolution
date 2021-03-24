using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAccounts();
        Task<AccountModel> GetAccountAsync(int id);
        Task<AccountModel> CreateAccountAsync(AccountModel model);
        Task<ResultModel> UpdateAccountAsync(AccountModel model);
    }
}
