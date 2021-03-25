using System;
using System.Collections.Generic;
using System.Text;

namespace bARTSolutionWeb.Domain.Services.Models
{
    public class CreateAccountModel
    {
        public string Name { get; set; }
        public string IncidentName { get; set; }
        public IEnumerable<string> ContactEmails { get; set; }
    }
}
