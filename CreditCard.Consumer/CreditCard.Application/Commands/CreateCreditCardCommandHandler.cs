using CreditCard.Domain.Entities;
using MediatR;

namespace CreditCard.Application.Commands
{
    public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand>
    {
        public async Task<Unit> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var customerCreditCard = new CreditCardEntity(request.CustomerId, request.RequestedCardType, request.CardRequestStatus, request.LimitApprovad);

            return Unit.Value;
        }
    }
}
