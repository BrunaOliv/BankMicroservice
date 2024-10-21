namespace CustomerRegistration.Domain.Entities
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public Guid CustomerId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
