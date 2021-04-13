using AutoMapper;

using bARTSolution.Domain.Data.Core;
using bARTSolution.Domain.Data.Entities;
using bARTSolution.Domain.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Infrastructure.Repositories.Implementation
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IGenericRepository<Incident> incidentRepository;

        private readonly IMapper mapper;

        public IncidentRepository(IGenericRepository<Incident> incidentRepository, IMapper mapper)
        {
            this.incidentRepository = incidentRepository;

            this.mapper = mapper;
        }

        public async Task<IncidentModel> CreateAsync(IncidentModel model)
        {
            var item = mapper.Map<Incident>(model);

            var result = await incidentRepository.CreateAsync(item);

            return mapper.Map<IncidentModel>(result);
        }

        public async Task<ResultModel> DeleteAsync(IncidentModel model)
        {
            var item = mapper.Map<Incident>(model);

            var result = await incidentRepository.RemoveAsync(item);

            return new ResultModel(result);
        }

        public async Task<ResultModel> DeleteAsync(string name)
        {
            var result = await incidentRepository.RemoveAsync(name);

            return new ResultModel(result);
        }

        public async Task<IEnumerable<IncidentModel>> GetAllAsync()
        {
            var result = mapper.Map<IEnumerable<IncidentModel>>(await incidentRepository.GetWithIncludeAsync<Account>(i => i.Accounts, x => (x as Account).Contacts));
            var a =  await incidentRepository.Get(include: x => x.Include(x => x.Accounts).ThenInclude(x => x.Contacts)).ToListAsync();

            return result;
        }

        public async Task<IncidentModel> GetByNameAsync(string name)
        {
            var result = await incidentRepository.FindAsync(name);

            return mapper.Map<IncidentModel>(result);
        }

        public async Task<ResultModel> UpdateAsync(IncidentModel model)
        {
            var item = mapper.Map<Incident>(model);

            var result = await incidentRepository.UpdateAsync(item);

            return new ResultModel(result);
        }
    }
}
