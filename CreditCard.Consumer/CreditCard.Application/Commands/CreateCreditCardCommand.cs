using CreditCard.Domain.Enuns;
using MediatR;

namespace CreditCard.Application.Commands
{
    public class CreateCreditCardCommand : IRequest
    {
        public int CustomerId { get; set; }
        public List<CreditCardCommand> CreditCards { get; set; }

        public class CreditCardCommand {
            public CardType RequestedCardType { get; set; }
            public CardStatus Status { get; set; }
            public decimal LimitApprovad { get; set; }
        }

    }
}
