using MediatR;

namespace CreditProposal.Application.Commands.CreateCreditProposal
{
    public class CreateCreditProposalCommand : IRequest
    {
        public int CustomerId { get; set; }
        public decimal MonthlyIncome { get; set; }
        public int EmploymentDuration { get; set; }
    }
}
