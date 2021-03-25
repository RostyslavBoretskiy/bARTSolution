namespace bARTSolution.Domain.Data.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
