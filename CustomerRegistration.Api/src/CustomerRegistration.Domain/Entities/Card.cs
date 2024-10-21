using CustomerRegistration.Domain.Enums;

namespace CustomerRegistration.Domain.Entities
{
    public class Card
    {
        public Guid CardId { get; set; }
        public Guid CustomerId { get; set; }
        public CardType CardType { get; set; }
        public CardStatus CardStatus { get; set; }
        public int PaymentDate { get; set; }
        public decimal? Limit { get; set; }
        public DateTime? CardExpirationDate { get; set; }

        public Card(CardType cardType, CardStatus cardStatus, int paymentDate)
        {
            CardType = cardType;
            CardStatus = cardStatus;
            PaymentDate = paymentDate;
        }

        public Card(Guid customerId, Guid cardId, CardType cardType, CardStatus cardStatus, int paymentDate, decimal? limit, DateTime? cardExpirationDate)
        {
            CustomerId = customerId;
            CardId = cardId;
            CardType = cardType;
            CardStatus = cardStatus;
            PaymentDate = paymentDate;
            Limit = limit;
            CardExpirationDate = cardExpirationDate;
        }

        public Card(Guid cardId, CardType cardType, CardStatus cardStatus, int paymentDate, decimal? limit, DateTime? cardExpirationDate)
        {
            CardId = cardId;
            CardType = cardType;
            CardStatus = cardStatus;
            PaymentDate = paymentDate;
            Limit = limit;
            CardExpirationDate = cardExpirationDate;
        }
    }

}
