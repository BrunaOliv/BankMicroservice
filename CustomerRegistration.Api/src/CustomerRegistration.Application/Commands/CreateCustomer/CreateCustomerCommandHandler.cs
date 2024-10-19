using AutoMapper;
using CustomerRegistration.Domain.Entities;
using CustomerRegistration.Domain.Interfaces;
using MediatR;

namespace CustomerRegistration.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IMessagePublisher _messagePublisher;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IMessagePublisher messagePublisher)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customer>(request);

            await _customerRepository.CreateCustomer(customerEntity);

            await _messagePublisher.SendMessageQueue();
            return Unit.Value;
        }
    }
}
