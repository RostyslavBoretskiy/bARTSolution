using bARTSolution.Domain.Infrastructure.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace bARTSolution.Domain.Infrastructure.Repositories
{
    public interface IIncidentRepository
    {
        IEnumerable<IncidentModel> GetAll();
        Task<IncidentModel> GetByNameAsync(string name);

        Task<IncidentModel> CreateAsync(IncidentModel model);

        Task<ResultModel> UpdateAsync(IncidentModel model);

        Task<ResultModel> DeleteAsync(IncidentModel model);
        Task<ResultModel> DeleteAsync(string name);
    }
}
