using System.Collections.Generic;

namespace bARTSolution.Domain.Infrastructure.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public string IncidentName { get; set; }

        public IEnumerable<ContactModel> Contacts { get; set; }
    }
}
