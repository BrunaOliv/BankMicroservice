using CreditProposal.Application.DTO_s;
using CreditProposal.Application.Interfaces;
using CreditProposal.Domain.Entities;
using CreditProposal.Domain.Enuns;
using MediatR;
using static CreditProposal.Application.DTO_s.CreditProposalMessage;

namespace CreditProposal.Application.Commands.CreateCreditProposal
{
    public class CreateCreditProposalCommandHandler : IRequestHandler<CreateCreditProposalCommand>
    {
        private static readonly Random _random = new Random();
        private readonly IMessagePublisher _messagePublisher;

        public CreateCreditProposalCommandHandler(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }
        public async Task<Unit> Handle(CreateCreditProposalCommand request, CancellationToken cancellationToken)
        {
            var customerScore = GetScore();

            var customerCreditProposal = new CreditProposalEntity(customerScore, request.MonthlyIncome, request.EmploymentDuration);


            foreach (var item in customerCreditProposal.Cards)
            {
                var matchingItem = request.RequestedCards.FirstOrDefault(l => l.CardType == item.CardType);
                if (matchingItem != null)
                {
                    item.CardId = matchingItem.CardId; 
                }

            }

            var creditsCardsApproval = new List<CreditCardMessage>();

            foreach (var card in customerCreditProposal.Cards)
            {
                var creditCardMessage = new CreditCardMessage(card.CardId, card.CardType, CardStatus.Approved, card.MaxLimit);
                creditsCardsApproval.Add(creditCardMessage);
            }

            var creditProposal = new CreditProposalMessage(request.CustomerId, creditsCardsApproval);

            await _messagePublisher.SendMessageQueue(creditProposal);

            return Unit.Value;
        }

        private int GetScore()
        {
            return _random.Next(350, 1000);
        }
    }
}
