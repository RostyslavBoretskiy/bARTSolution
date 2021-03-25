using bARTSolution.Domain.Infrastructure.Models;
using bARTSolutionWeb.Domain.Services.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<IncidentModel>> GetIncidents();
        Task<IncidentModel> GetIncident(string name);
        Task<IncidentModel> CreateIncidentAsync(CreateIncidentModel model);
        Task<ResultModel> UpdateIncident(IncidentModel model);
    }
}
