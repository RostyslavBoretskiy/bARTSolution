using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolutionWeb.Domain.Services
{
    public interface IContactService
    {
        IEnumerable<ContactModel> GetModels();
        Task<ContactModel> GetModelAsync(int id);
        Task<ContactModel> CreateContactAsync(ContactModel model);
        Task<ResultModel> UpdateContactAsync(ContactModel model);
    }
}
