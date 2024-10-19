using CustomerRegistration.Domain.Entities;

namespace CustomerRegistration.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomer(Customer customer);
    }
}
