using System.Text.RegularExpressions;

namespace CustomerRegistration.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        private string _cpf;
        public string? Cpf
        {
            get => _cpf;
            set => _cpf = CleanNonNumericCharacters(value);
        }

        private string _rg;
        public string Rg
        {
            get => _rg;
            set => _rg = CleanNonNumericCharacters(value);
        }
        public string IssuingAuthority { get; set; }
        public char Gender { get; set; }  //gender (M/F)
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public Contact Contact { get; set; }
        public Address? Address { get; set; }
        public FinancialInformation FinancialInformation { get; set; }
        public List<Card> Cards { get; set; }

        private string? CleanNonNumericCharacters(string? input)
        {
            return input is null ? null : Regex.Replace(input, @"[^\d]", "");
        }

    }
}
