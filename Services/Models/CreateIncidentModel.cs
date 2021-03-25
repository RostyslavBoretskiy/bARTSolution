using System.ComponentModel.DataAnnotations;

namespace bARTSolutionWeb.Domain.Services.Models
{
    public class CreateIncidentModel
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
