using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services.Implementation
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
            var contact = await contactRepository.GetByEmailAsync(model.Email);

            if (contact != null)
            {
                var result = await UpdateContactAsync(model);
                if (result.IsDone)
                    return contact;
                else
                    return null;
            }
            else
            {
                return await contactRepository.CreateAsync(model);
            }
        }

        public async Task<ContactModel> GetContactByEmailAsync(string email)
        {
            return await contactRepository.GetByEmailAsync(email);
        }

        public Task<IEnumerable<ContactModel>> GetContactByEmailsAsync(IEnumerable<string> emails)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ContactModel> GetContactByIdAsync(int id)
        {
            return await contactRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ContactModel>> GetContactsAsync()
        {
            return await contactRepository.GetAllAsync();
        }

        public async Task<ResultModel> UpdateContactAsync(ContactModel model)
        {
            return await contactRepository.UpdateAsync(model);
        }
    }
}
