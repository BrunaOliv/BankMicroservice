using CreditCard.Domain.Entities;
using MediatR;

namespace CreditCard.Application.Commands
{
    public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand>
    {
        public async Task<Unit> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditCards = new List<CreditCardEntity>();

            foreach (var creditCard in request.CreditCards)
            {
                var newCreditCard = new CreditCardEntity(request.CustomerId, creditCard.RequestedCardType, creditCard.Status, creditCard.LimitApprovad);
                creditCards.Add(newCreditCard);
            }
            

            return Unit.Value;
        }
    }
}
