using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;
using bARTSolutionWeb.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using bARTSolutionWeb.Domain.Services;

namespace bARTSolution.Domain.Services.Implementation
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IContactService contactService;
        private readonly ITransactionService transactionService;

        public IncidentService(
            IIncidentRepository incidentRepository, 
            IAccountRepository accountRepository,
            IContactService contactService,
            ITransactionService transactionService)
        {
            this.incidentRepository = incidentRepository;
            this.accountRepository = accountRepository;
            this.contactService = contactService;
            this.transactionService = transactionService;
        }

        public async Task<IncidentModel> CreateIncidentAsync(CreateIncidentModel model)
        {
            transactionService.Begin();

            var account = await accountRepository.GetByNameAsync(model.AccountName);
            var contact = await contactService.GetContactByEmailAsync(model.Email);

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
                await contactService.CreateContactAsync(contactModel);
            }
            else
            {
                contactModel.ContactId = contact.ContactId;
                await contactService.UpdateContactAsync(contactModel);
            }

            if (!account.Contacts.Any(c => c.ContactId.Equals(contact.ContactId)))
            {
                account.Contacts.ToList().Add(contact);
                await accountRepository.UpdateAsync(account); 
            }

            var incident = await incidentRepository.GetByNameAsync(account.IncidentName);
            incident.Description = model.Description;

            await incidentRepository.UpdateAsync(incident);

            return incident;
        }

        public Task<IncidentModel> GetIncident(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncidentModel>> GetIncidents()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> UpdateIncident(IncidentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
