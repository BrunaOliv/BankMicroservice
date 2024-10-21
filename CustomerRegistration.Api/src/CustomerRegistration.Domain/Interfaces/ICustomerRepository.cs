using CustomerRegistration.Domain.Entities;

namespace CustomerRegistration.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Guid> CreateCustomer(Customer customer);
        Task UpdateCustomerCreditCard(List<Card> cards);
        Task<List<Card>> GetCustomerCreditCardsAsync(Guid customerId);
    }
}
