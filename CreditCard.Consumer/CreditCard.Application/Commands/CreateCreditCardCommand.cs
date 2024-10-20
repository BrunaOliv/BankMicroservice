using CreditCard.Domain.Enuns;
using MediatR;

namespace CreditCard.Application.Commands
{
    public class CreateCreditCardCommand : IRequest
    {
        public int CustomerId { get; set; }
        public CardType RequestedCardType { get; set; }
        public CardRequestStatus CardRequestStatus { get; set; }
        public decimal LimitApprovad { get; set; }
    }
}
