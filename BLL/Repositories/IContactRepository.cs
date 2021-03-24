using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Infrastructure.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<ContactModel> GetAll();
        Task<ContactModel> GetByIdAsync(int id);

        Task<ContactModel> CreateAsync(ContactModel model);

        Task<ResultModel> UpdateAsync(ContactModel model);

        Task<ResultModel> DeleteAsync(ContactModel model);
        Task<ResultModel> DeleteAsync(int id);
    }
}
