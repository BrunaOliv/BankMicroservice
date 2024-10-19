using CustomerRegistration.Domain.Enums;
using MediatR;

namespace CustomerRegistration.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
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
        public List<CardCommand>? Cards { get; set; }

        public class ContactCommand
        {
            public int ContactId { get; set; }
            public int CustomerId { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }
        }

        public class AddressCommand
        {
            public int AddressId { get; set; }
            public int CustomerId { get; set; }
            public string? Street { get; set; }
            public int? Number { get; set; }
            public string? Neighborhood { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
        }

        public class FinancialInformationCommand
        {
            public int FinancialInfoId { get; set; }
            public int CustomerId { get; set; }
            public decimal? MonthlyIncome { get; set; }
            public string? Occupation { get; set; }
            public string? CompanyName { get; set; }
            public int? EmploymentDuration { get; set; }
            public int? CreditScore { get; set; }
        }

        public class CardCommand
        {
            public int CardId { get; set; }
            public int CustomerId { get; set; }
            public string? CardType { get; set; }
            public decimal? RequestedLimit { get; set; }
            public decimal? RequestedCreditAmount { get; set; }
            public int? PaymentTerm { get; set; }
            public float? InterestRate { get; set; }
            public int? BranchNumber { get; set; }
            public string? AccountNumber { get; set; }
            public StatusCard StatusCard { get; set; }
        }
    }
}
