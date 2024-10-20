using CreditCard.Application.DTOs;

namespace CreditCard.Application.Interfaces
{
    public interface IMessagePublisher
    {
        Task SendMessageQueue(CreditCardMessage creditCardMessage);
    }
}
