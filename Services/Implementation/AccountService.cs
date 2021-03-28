using AutoMapper;

using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;
using bARTSolutionWeb.Domain.Services.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bARTSolution.Domain.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IContactService contactService;

        private readonly IMapper mapper;

        public AccountService(
            IAccountRepository accountRepository, 
            IContactService contactService,
            IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.contactService = contactService;

            this.mapper = mapper;
        }

        public async Task<ResultModel> AddContact(string accountName, ContactViewModel contactVM)
        {
            if (contactVM == null)
                throw new NullReferenceException($"{nameof(contactVM)} can not be null.");

            var account = await GetAccountAsync(accountName);
            var contact = await contactService.GetContactByEmailAsync(contactVM.Email);

            if (account == null)
                return new ResultModel(false);

            var id = contact.ContactId;
            contact = mapper.Map<ContactModel>(contactVM);
            contact.ContactId = id;
            contact.AccountId = account.AccountId;

            if (contact == null)
                await contactService.CreateContactAsync(contact);
            else
                await contactService.UpdateContactAsync(contact);

            return new ResultModel();
        }

        public async Task<AccountModel> CreateAccountAsync(AccountViewModel model)
        {
            var contact = await contactService.GetContactByEmailAsync(model.Email);
            var newAccount = new AccountModel() { Name = model.Name };

            var createdResult = await accountRepository.CreateAsync(newAccount);

            contact.AccountId = createdResult.AccountId;
            await contactService.UpdateContactAsync(contact);

            return createdResult;
        }

        public async Task<ResultModel> DeleteAccountAsync(int id)
        {
            return await accountRepository.DeleteAsync(id);
        }

        public async Task<AccountModel> GetAccountAsync(int id)
        {
            return await accountRepository.GetByIdAsync(id);
        }

        public async Task<AccountModel> GetAccountAsync(string name)
        {
            return await accountRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<AccountModel>> GetAccountsAsync()
        {
            return await accountRepository.GetAllAsync();
        }

        public async Task<ResultModel> UpdateAccountAsync(AccountModel model)
        {
            return await accountRepository.UpdateAsync(model);
        }

        public Task<ResultModel> UpsertAccountAsync(AccountModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
