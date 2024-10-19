using AutoMapper;
using CustomerRegistration.Application.Commands.CreateCustomer;
using CustomerRegistration.Domain.Entities;
using static CustomerRegistration.Application.Commands.CreateCustomer.CreateCustomerCommand;

namespace CustomerRegistration.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<ContactCommand, Contact>();
            CreateMap<AddressCommand, Address>();
            CreateMap<FinancialInformationCommand, FinancialInformation>();
            CreateMap<CardCommand, Card>();
        }
    }
}
