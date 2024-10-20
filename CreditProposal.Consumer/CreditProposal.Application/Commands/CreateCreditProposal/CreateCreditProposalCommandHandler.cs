using CreditProposal.Domain.Entities;
using MediatR;

namespace CreditProposal.Application.Commands.CreateCreditProposal
{
    public class CreateCreditProposalCommandHandler : IRequestHandler<CreateCreditProposalCommand>
    {
        private static readonly Random _random = new Random();
        public async Task<Unit> Handle(CreateCreditProposalCommand request, CancellationToken cancellationToken)
        {
            var customerScore = GetScore();
            var customerCreditProposal = new CreditProposalEntity(customerScore, request.MonthlyIncome, request.EmploymentDuration);

            return Unit.Value;
        }

        private int GetScore()
        {
            return _random.Next(350, 1000);
        }
    }
}
