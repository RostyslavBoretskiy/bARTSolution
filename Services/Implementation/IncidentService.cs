using AutoMapper;

using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;
using bARTSolutionWeb.Domain.Services.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services.Implementation
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IAccountService accountService;
        private readonly ITransactionService transactionService;

        private readonly IMapper mapper;

        public IncidentService(
            IIncidentRepository incidentRepository,
            IAccountService accountService,
            ITransactionService transactionService,
            IMapper mapper)
        {
            this.incidentRepository = incidentRepository;
            this.accountService = accountService;
            this.transactionService = transactionService;

            this.mapper = mapper;
        }

        public async Task<IncidentModel> CreateIncidentAsync(IncidentViewModel model)
        {
            transactionService.Begin();

            var account = await accountService.GetAccountAsync(model.AccountName);

            if (account == null)
                throw new NullReferenceException($"Account with email: {model.Email} - not exist.");

            var contactVM = mapper.Map<ContactViewModel>(model);
            var contactHandlerResult = await accountService.AddContact(model.AccountName, contactVM);

            var incident = new IncidentModel() { Description = model.Description };
            incident = await incidentRepository.CreateAsync(incident); 

            account.IncidentName = incident.Name;
            var accountHandlerResult = await accountService.UpdateAccountAsync(account);

            if (contactHandlerResult.IsDone && accountHandlerResult.IsDone)
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
