using CustomerRegistration.Domain.Enums;
using MediatR;

namespace CustomerRegistration.Application.Commands.UpdateCustomerCreditCard
{
    public class UpdateCustomerCreditCardCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public List<CreditCardCommand> CreditCards { get; set; }

        public class CreditCardCommand
        {
            public Guid CardId { get; set; }
            public CardType CardType { get; set; }
            public CardStatus CardStatus { get; set; }
            public decimal Limit { get; set; }
            public DateTime CardExpirationDate { get; set; }
            public int PaymentDate { get; set; }
        }
    }
}
