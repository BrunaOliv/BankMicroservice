namespace CustomerRegistration.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? IssuingAuthority { get; set; }
        public char? Gender { get; set; }  //gender (M/F)
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public Contact? Contact { get; set; }
        public Address? Address { get; set; }
        public FinancialInformation? FinancialInformation { get; set; }
        public List<Card> Cards { get; set; }

    }
}
