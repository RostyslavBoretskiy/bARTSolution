using System.ComponentModel.DataAnnotations;

namespace bARTSolutionWeb.Domain.Services.Models
{
    public class AccountViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
