namespace bARTSolution.Domain.Infrastructure.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AccountId { get; set; }
    }
}
