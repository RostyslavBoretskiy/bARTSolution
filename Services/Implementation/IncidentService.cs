using bARTSolution.Domain.Infrastructure.Models;
using bARTSolution.Domain.Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services.Implementation
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IContactRepository contactRepository;

        public IncidentService(
            IIncidentRepository incidentRepository, 
            IAccountRepository accountRepository, 
            IContactRepository contactRepository)
        {
            this.incidentRepository = incidentRepository;
            this.accountRepository = accountRepository;
            this.contactRepository = contactRepository;
        }

        public Task<IncidentModel> CreateIncident(IncidentModel model)
        {
            throw new NotImplementedException();
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
