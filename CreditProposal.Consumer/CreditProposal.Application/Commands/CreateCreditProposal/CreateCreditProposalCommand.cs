using CreditProposal.Domain.Enuns;
using MediatR;

namespace CreditProposal.Application.Commands.CreateCreditProposal
{
    public class CreateCreditProposalCommand : IRequest
    {
        public int CustomerId { get; set; }
        public decimal MonthlyIncome { get; set; }
        public int EmploymentDuration { get; set; }
        public List<RequestedCard> RequestedCards { get; set; }

        public class RequestedCard
        {
            public CardType CardType { get; set; }
            public CardStatus Status { get; set; }
            public int PaymentDate { get; set; }
        }
    }
}
