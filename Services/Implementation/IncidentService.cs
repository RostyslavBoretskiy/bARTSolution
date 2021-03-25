using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;
using bARTSolutionWeb.Domain.Services.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services.Implementation
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IAccountService accountService;
        private readonly IContactService contactService;
        private readonly ITransactionService transactionService;

        public IncidentService(
            IIncidentRepository incidentRepository,
            IAccountService accountService,
            IContactService contactService,
            ITransactionService transactionService)
        {
            this.incidentRepository = incidentRepository;
            this.accountService = accountService;
            this.contactService = contactService;
            this.transactionService = transactionService;
        }

        public async Task<IncidentModel> CreateIncidentAsync(CreateIncidentModel model)
        {
            //transactionService.Begin();

            bool isCreatingCorrect = false;

            var account222 = await accountService.GetAccountsAsync();
            var account = account222.FirstOrDefault(f => f.Name == model.AccountName);
            var contact222 = await contactService.GetContactsAsync();
            var contact = contact222.FirstOrDefault(f => f.Email == model.Email);

            if (account == null)
                return null;

            var contactModel = new ContactModel()
            {
                AccountId = account.AccountId,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            if (contact == null)
            {
                contact = await contactService.CreateContactAsync(contactModel);
                if (contact != null)
                    isCreatingCorrect = true;
            }
            else
            {
                contactModel.ContactId = contact.ContactId;
                var updatedContactResult = await contactService.UpdateContactAsync(contactModel);
                isCreatingCorrect = updatedContactResult.IsDone;
            }

            //if (!account.Contacts.Any(c => c.ContactId.Equals(contact.ContactId)))
            //{
            //    account.Contacts = new List<ContactModel>() { contact };
            //    var updatedAccountResult = await accountService.UpdateAccountAsync(account);
            //    isCreatingCorrect = updatedAccountResult.IsDone;
            //}

            //AccountModel modelAcc = new AccountModel() { AccountId = account.AccountId, Contacts = account.Contacts, Name = account.Name };
            var incident = new IncidentModel() { Description = model.Description };

            incident = await incidentRepository.CreateAsync(incident);

            account.IncidentName = incident.Name;
            await accountService.UpdateAccountAsync(account);

            if (isCreatingCorrect)
                transactionService.Commit();
            else
                transactionService.Rollback();

            return incident;
        }

        public async Task<ResultModel> DeleteIncidentAsync(string name)
        {
            return await incidentRepository.DeleteAsync(name);
        }

        public async Task<IncidentModel> GetIncidentAsync(string name)
        {
            return await incidentRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<IncidentModel>> GetIncidentsAsync()
        {
            return await incidentRepository.GetAllAsync();
        }

        public async Task<ResultModel> UpdateIncidentAsync(IncidentModel model)
        {
            return await incidentRepository.UpdateAsync(model);
        }
    }
}
