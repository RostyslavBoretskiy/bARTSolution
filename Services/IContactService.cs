using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactModel>> GetContactsAsync();
        Task<ContactModel> GetContactByIdAsync(int id);
        Task<ContactModel> GetContactByEmailAsync(string email);
        Task<IEnumerable<ContactModel>> GetContactByEmailsAsync(IEnumerable<string> emails);
        Task<ContactModel> CreateContactAsync(ContactModel model);
        Task<ResultModel> UpdateContactAsync(ContactModel model);
        Task<ResultModel> DeleteContactAsync(int id);
    }
}
