using MediatR;

namespace CustomerRegistration.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
