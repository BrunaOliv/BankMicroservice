using CustomerRegistration.Domain.Enums;
using MediatR;

namespace CustomerRegistration.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? IssuingAuthority { get; set; }
        public string? Gender { get; set; }  //gender (M/F)
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public ContactCommand? Contact { get; set; }
        public AddressCommand? Address { get; set; }
        public FinancialInformationCommand? FinancialInformation { get; set; }
        public List<CardCommand> RequestedCards { get; set; }

        public class ContactCommand
        {
            public string? Phone { get; set; }
            public string? Email { get; set; }
        }

        public class AddressCommand
        {
            public string? Street { get; set; }
            public int? Number { get; set; }
            public string? Neighborhood { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
        }

        public class FinancialInformationCommand
        {
            public decimal? MonthlyIncome { get; set; }
            public string? Occupation { get; set; }
            public string? CompanyName { get; set; }
            public int? EmploymentDuration { get; set; }
            public int? CreditScore { get; set; }
        }

        public class CardCommand
        {
            public CardType CardType { get; set; }
            public CardStatus StatusCard { get; set; } = CardStatus.PendingApproval;
            public int PaymentDate { get; set; }
        }
    }
}
