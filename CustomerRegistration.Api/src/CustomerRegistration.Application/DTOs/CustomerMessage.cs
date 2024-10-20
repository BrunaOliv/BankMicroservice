using CustomerRegistration.Domain.Enums;

namespace CustomerRegistration.Application.DTOs
{
    public class CustomerMessage
    {
        public int CustomerId { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public int? EmploymentDuration { get; set; }
        public List<RequestedCard> RequestedCards { get; set; }

        public class RequestedCard
        {
            public RequestedCard(CardType cardType, CardStatus status, int paymentDate)
            {
                CardType = cardType;
                Status = status;
                PaymentDate = paymentDate;
            }
            public CardType CardType { get; set; }
            public CardStatus Status { get; set; }
            public int PaymentDate { get; set; }
        }
    }
}
