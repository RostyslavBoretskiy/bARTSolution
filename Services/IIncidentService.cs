using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<IncidentModel>> GetIncidents();
        Task<IncidentModel> GetIncident(string name);
        Task<IncidentModel> CreateIncident(IncidentModel model);
        Task<ResultModel> UpdateIncident(IncidentModel model);
    }
}
