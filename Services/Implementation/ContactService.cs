using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolutionWeb.Domain.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<ContactModel> CreateContactAsync(ContactModel model)
        {
            return await contactRepository.CreateAsync(model);
        }

        public async Task<ContactModel> GetModelAsync(int id)
        {
            return await contactRepository.GetByIdAsync(id);
        }

        public IEnumerable<ContactModel> GetModels()
        {
            return contactRepository.GetAll();
        }

        public async Task<ResultModel> UpdateContactAsync(ContactModel model)
        {
            return await contactRepository.UpdateAsync(model);
        }
    }
}
