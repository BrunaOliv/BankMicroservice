using CustomerRegistration.Domain.Entities;
using CustomerRegistration.Domain.Interfaces;
using MediatR;

namespace CustomerRegistration.Application.Commands.UpdateCustomerCreditCard
{
    public class UpdateCustomerCreditCardCommandHandler : IRequestHandler<UpdateCustomerCreditCardCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCreditCardCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Unit> Handle(UpdateCustomerCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditCards = new List<Card>();
            foreach (var creditCard in request.CreditCards)
            {
                var newCreditCard = new Card(creditCard.CardId, creditCard.CardType, creditCard.CardStatus, creditCard.PaymentDate, creditCard.Limit,creditCard.CardExpirationDate);
                creditCards.Add(newCreditCard);
            }

            await _customerRepository.UpdateCustomerCreditCard(creditCards);

            return Unit.Value;
        }
    }
}
