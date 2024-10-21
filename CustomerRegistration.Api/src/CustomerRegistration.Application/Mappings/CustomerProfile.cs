using AutoMapper;
using CustomerRegistration.Application.Commands.CreateCustomer;
using CustomerRegistration.Application.Commands.UpdateCustomerCreditCard;
using CustomerRegistration.Domain.Entities;
using static CustomerRegistration.Application.Commands.CreateCustomer.CreateCustomerCommand;

namespace CustomerRegistration.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<CreateCustomerCommand, Customer>()
            //    .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src.RequestedCards));
            CreateMap<ContactCommand, Contact>();
            CreateMap<AddressCommand, Address>();
            CreateMap<FinancialInformationCommand, FinancialInformation>();
            CreateMap<CardCommand, Card>()
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
            .ForMember(dest => dest.CardId, opt => opt.Ignore())
            .ForMember(dest => dest.Limit, opt => opt.Ignore())
            .ForMember(dest => dest.CardExpirationDate, opt => opt.Ignore());

            CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(dest => dest.Cards, opt => opt.MapFrom(src =>
                src.RequestedCards.Select(c => new Card(c.CardType, c.StatusCard, c.PaymentDate))));
        }
    }
}
