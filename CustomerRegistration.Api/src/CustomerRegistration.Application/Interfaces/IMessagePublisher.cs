using CustomerRegistration.Application.DTOs;

namespace CustomerRegistration.Application.Interfaces
{
    public interface IMessagePublisher
    {
        Task SendMessageQueue(CustomerMessage customerMessage);
    }
}
