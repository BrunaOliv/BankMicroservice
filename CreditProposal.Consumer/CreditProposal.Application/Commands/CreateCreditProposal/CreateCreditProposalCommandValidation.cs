using FluentValidation;

namespace CreditProposal.Application.Commands.CreateCreditProposal
{
    public class CreateCreditProposalCommandValidator : AbstractValidator<CreateCreditProposalCommand>
    {
        public CreateCreditProposalCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("O ID do cliente não pode ser vazio.");

            RuleFor(x => x.MonthlyIncome)
                .GreaterThan(0).WithMessage("A renda mensal deve ser maior que zero.");

            RuleFor(x => x.EmploymentDuration)
                .GreaterThanOrEqualTo(1).WithMessage("A duração do emprego deve ser de pelo menos 1 mês.");

            RuleFor(x => x.RequestedCards)
                .NotNull().WithMessage("A lista de cartões não pode ser nula.")
                .NotEmpty().WithMessage("A lista de cartões não pode estar vazia.");

            RuleForEach(x => x.RequestedCards).SetValidator(new RequestedCardValidator());
        }
    }

    public class RequestedCardValidator : AbstractValidator<CreateCreditProposalCommand.RequestedCard>
    {
        public RequestedCardValidator()
        {
            RuleFor(x => x.CardId)
                .NotEmpty().WithMessage("O ID do cartão não pode ser vazio.");

            RuleFor(x => x.CardType)
                .IsInEnum().WithMessage("O tipo de cartão é inválido.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("O status do cartão é inválido.");

            RuleFor(x => x.PaymentDate)
                .InclusiveBetween(1, 31).WithMessage("A data de pagamento deve ser entre 1 e 31.");
        }
    }
}
