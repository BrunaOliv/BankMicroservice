namespace CustomerRegistration.Domain.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
