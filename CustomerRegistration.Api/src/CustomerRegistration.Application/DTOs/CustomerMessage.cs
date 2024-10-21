using CustomerRegistration.Domain.Enums;

namespace CustomerRegistration.Application.DTOs
{
    public class CustomerMessage
    {
        public Guid CustomerId { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public int? EmploymentDuration { get; set; }
        public List<RequestedCard> RequestedCards { get; set; }

        public class RequestedCard
        {
            public RequestedCard(Guid cardId, CardType cardType, CardStatus status, int paymentDate)
            {
                CardId = cardId;
                CardType = cardType;
                Status = status;
                PaymentDate = paymentDate;
            }
            public Guid CardId { get; set; }
            public CardType CardType { get; set; }
            public CardStatus Status { get; set; }
            public int PaymentDate { get; set; }
        }
    }
}
