using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<AccountModel> GetAll();
        Task<AccountModel> GetByIdAsync(int id);
        AccountModel GetByName(string name);

        Task<AccountModel> CreateAsync(AccountModel model);

        Task<ResultModel> UpdateAsync(AccountModel model);

        Task<ResultModel> DeleteAsync(AccountModel model);
        Task<ResultModel> DeleteAsync(int id);
    }
}
