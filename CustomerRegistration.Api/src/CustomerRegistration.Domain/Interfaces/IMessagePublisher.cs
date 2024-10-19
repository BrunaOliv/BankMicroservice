namespace CustomerRegistration.Domain.Interfaces
{
    public interface IMessagePublisher
    {
        Task SendMessageQueue();
    }
}
