using System.ComponentModel.DataAnnotations;

namespace bARTSolutionWeb.Domain.Services.Models
{
    public class ContactViewModel
    {
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
