using FluentValidation;

namespace CustomerRegistration.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
               RuleFor(customer => customer.FullName)
                .NotEmpty().WithMessage("O nome completo é obrigatório.")
                .Length(2, 100).WithMessage("O nome completo deve ter entre 2 e 100 caracteres.");
        }
    }
}
