using CustomerRegistration.Domain.Enums;

namespace CustomerRegistration.Domain.Entities
{
    public class Card
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public CardType CardType { get; set; }
        public CardStatus CardStatus { get; set; }
        public int PaymentDate { get; set; }
        public decimal? Limit { get; set; }
        public DateTime? CardExpirationDate { get; set; }

        public Card(int customerId, CardType cardType, CardStatus cardStatus, int paymentDate, decimal? limit, DateTime? cardExpirationDate)
        {
            CustomerId = customerId;
            CardType = cardType;
            CardStatus = cardStatus;
            PaymentDate = paymentDate;
            Limit = limit;
            CardExpirationDate = cardExpirationDate;
        }
    }

}
