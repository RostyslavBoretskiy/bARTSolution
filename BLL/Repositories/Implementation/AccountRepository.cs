using AutoMapper;

using bARTSolution.Domain.Data.Core;
using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bARTSolution.Domain.Infrastructure.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IGenericRepository<Account> accountRepository;

        private readonly IMapper mapper;

        public AccountRepository(IGenericRepository<Account> accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;

            this.mapper = mapper;
        }

        public async Task<AccountModel> CreateAsync(AccountModel model)
        {
            var item = mapper.Map<Account>(model);

            var result = await accountRepository.CreateAsync(item);

            return mapper.Map<AccountModel>(result);
        }

        public async Task<ResultModel> DeleteAsync(AccountModel model)
        {
            var item = mapper.Map<Account>(model);

            var result = await accountRepository.RemoveAsync(item);

            return new ResultModel(result);
        }

        public async Task<ResultModel> DeleteAsync(int id)
        {
            var result = await accountRepository.RemoveAsync(id);

            return new ResultModel(result);
        }

        public IEnumerable<AccountModel> GetAll()
        {
            var result = mapper.Map<IEnumerable<AccountModel>>(accountRepository.Get());

            return result;
        }

        public async Task<AccountModel> GetByIdAsync(int id)
        {
            var result = await accountRepository.FindAsync(id);

            return mapper.Map<AccountModel>(result);
        }

        public AccountModel GetByName(string name)
        {
            var result = accountRepository
                .Get(a => a.Name.Equals(name))
                .FirstOrDefault();

            return mapper.Map<AccountModel>(result);
        }

        public async Task<ResultModel> UpdateAsync(AccountModel model)
        {
            var item = mapper.Map<Account>(model);

            var result = await accountRepository.UpdateAsync(item);

            return new ResultModel(result);
        }
    }
}
