using System.Collections.Generic;

namespace bARTSolution.Domain.Data.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public string IncidentName { get; set; }
        public Incident Incident { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
