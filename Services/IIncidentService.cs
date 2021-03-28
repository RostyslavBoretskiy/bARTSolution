using bARTSolution.Domain.Infrastructure.Models;
using bARTSolutionWeb.Domain.Services.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<IncidentModel>> GetIncidentsAsync();
        Task<IncidentModel> GetIncidentAsync(string name);
        Task<IncidentModel> CreateIncidentAsync(IncidentViewModel model);
        Task<ResultModel> UpdateIncidentAsync(IncidentModel model);
        Task<ResultModel> DeleteIncidentAsync(string name);
    }
}
