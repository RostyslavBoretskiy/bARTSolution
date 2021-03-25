using AutoMapper;

using bARTSolution.Domain.Data.Core;
using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Infrastructure.Repositories.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly IGenericRepository<Contact> contactRepository;

        private readonly IMapper mapper;

        public ContactRepository(IGenericRepository<Contact> contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;

            this.mapper = mapper;
        }

        public async Task<ContactModel> CreateAsync(ContactModel model)
        {
            var item = mapper.Map<Contact>(model);

            var result = await contactRepository.CreateAsync(item);

            return mapper.Map<ContactModel>(result);
        }

        public async Task<ResultModel> DeleteAsync(ContactModel model)
        {
            var item = mapper.Map<Contact>(model);

            var result = await contactRepository.RemoveAsync(item);

            return new ResultModel(result);
        }

        public async Task<ResultModel> DeleteAsync(int id)
        {
            var result = await contactRepository.RemoveAsync(id);

            return new ResultModel(result);
        }

        public async Task<IEnumerable<ContactModel>> GetAllAsync()
        {
            var result = mapper.Map<IEnumerable<ContactModel>>(await contactRepository.GetAsync());

            return result;
        }

        public async Task<ContactModel> GetByEmailAsync(string email)
        {
            var result = await contactRepository
                .GetAsync(c => c.Email == email);

            return mapper.Map<ContactModel>(result.FirstOrDefault());
        }

        public async Task<ContactModel> GetByIdAsync(int id)
        {
            var result = await contactRepository.FindAsync(id);

            return mapper.Map<ContactModel>(result);
        }

        public async Task<ResultModel> UpdateAsync(ContactModel model)
        {
            var item = mapper.Map<Contact>(model);

            var result = await contactRepository.UpdateAsync(item);

            return new ResultModel(result);
        }
    }
}
