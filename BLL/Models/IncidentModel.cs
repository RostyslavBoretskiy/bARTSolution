using System.Collections.Generic;

namespace bARTSolution.Domain.Infrastructure.Models
{
    public class IncidentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AccountModel> Accounts { get; set; }
    }
}
