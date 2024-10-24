using FluentValidation;
using System.Text.RegularExpressions;

namespace CustomerRegistration.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("Nome completo é obrigatório.")
                .MinimumLength(3).WithMessage("Nome completo deve ter no mínimo 3 caracteres.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("Data de nascimento deve ser no passado.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Must(BeValidCpf).WithMessage("CPF inválido.");

            RuleFor(c => c.Rg)
                .NotEmpty().WithMessage("RG é obrigatório.")
                .Must(BeValidRg).WithMessage("RG inválido.");

            RuleFor(c => c.IssuingAuthority)
                .NotEmpty().WithMessage("Órgão emissor é obrigatório.");

            RuleFor(c => c.Gender)
                .NotEmpty().WithMessage("Gênero é obrigatório.")
                .Must(g => g == "M" || g == "F").WithMessage("Gênero deve ser 'M' ou 'F'.");

            RuleFor(c => c.Nationality)
                .NotEmpty().WithMessage("Nacionalidade é obrigatória.");

            RuleFor(c => c.MaritalStatus)
                .NotEmpty().WithMessage("Estado civil é obrigatório.");

            RuleForEach(c => c.RequestedCards)
                .SetValidator(new CardCommandValidator());

            RuleFor(c => c.Contact)
                .NotNull().WithMessage("Contato é obrigatório.")
                .SetValidator(new ContactCommandValidator());

            RuleFor(c => c.Address)
                .NotNull().WithMessage("Endereço é obrigatório.")
                .SetValidator(new AddressCommandValidator());

            RuleFor(c => c.FinancialInformation)
                .NotNull().WithMessage("Informações financeiras são obrigatórias.")
                .SetValidator(new FinancialInformationCommandValidator());
        }

        private bool BeValidCpf(string cpf) => Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

        private bool BeValidRg(string rg) => Regex.IsMatch(rg, @"^\d{2}\.\d{3}\.\d{3}-\d{1}$");

    }

    public class ContactCommandValidator : AbstractValidator<CreateCustomerCommand.ContactCommand>
    {
        public ContactCommandValidator()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Telefone é obrigatório.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");
        }
    }

    public class AddressCommandValidator : AbstractValidator<CreateCustomerCommand.AddressCommand>
    {
        public AddressCommandValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("Rua é obrigatória.");

            RuleFor(a => a.Number)
                .NotNull().WithMessage("Número é obrigatório.");

            RuleFor(a => a.Neighborhood)
                .NotEmpty().WithMessage("Bairro é obrigatório.");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("Cidade é obrigatória.");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("Estado é obrigatório.");

            RuleFor(a => a.PostalCode)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .MaximumLength(10).WithMessage("CEP deve conter no maximo 10 caracteres");
        }
    }

    public class FinancialInformationCommandValidator : AbstractValidator<CreateCustomerCommand.FinancialInformationCommand>
    {
        public FinancialInformationCommandValidator()
        {
            RuleFor(f => f.MonthlyIncome)
                .NotNull().WithMessage("Renda mensal é obrigatória.")
                .GreaterThan(0).WithMessage("Renda mensal deve ser maior que zero.");

            RuleFor(f => f.Occupation)
                .NotEmpty().WithMessage("Ocupação é obrigatória.");

            RuleFor(f => f.CompanyName)
                .NotEmpty().WithMessage("Nome da empresa é obrigatório.");

            RuleFor(f => f.EmploymentDuration)
                .NotNull().WithMessage("Tempo de emprego é obrigatório.");
        }
    }

    // Validator para CardCommand
    public class CardCommandValidator : AbstractValidator<CreateCustomerCommand.CardCommand>
    {
        public CardCommandValidator()
        {
            RuleFor(c => c.CardType)
                .IsInEnum().WithMessage("Tipo de cartão inválido.");

            RuleFor(c => c.PaymentDate)
                .InclusiveBetween(1, 31).WithMessage("Data de pagamento deve ser entre 1 e 31.");
        }
    }
}
