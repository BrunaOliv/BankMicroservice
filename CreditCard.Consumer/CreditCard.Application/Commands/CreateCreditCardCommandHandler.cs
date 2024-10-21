using CreditCard.Application.Interfaces;
using CreditCard.Domain.Entities;
using MediatR;

namespace CreditCard.Application.Commands
{
    public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand>
    {
        private readonly IMessagePublisher _messagePublisher;

        public CreateCreditCardCommandHandler(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditCards = new List<CreditCardEntity>();

            foreach (var creditCard in request.CreditCards)
            {
                var newCreditCard = new CreditCardEntity(request.CustomerId, creditCard.CardId, creditCard.RequestedCardType, creditCard.Status, creditCard.LimitApprovad);
                creditCards.Add(newCreditCard);
            }

            await _messagePublisher.SendMessageQueue(new DTOs.CreditCardMessage(request.CustomerId, creditCards));

            return Unit.Value;
        }
    }
}
