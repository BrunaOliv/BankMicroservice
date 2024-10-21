using CreditCard.Domain.Enuns;

namespace CreditCard.Domain.Entities
{
    public class CreditCardEntity
    {
        public Guid CustomerId { get; set; }
        public Guid CardId { get; set; }
        public CardType CardType { get; set; }
        public CardStatus CardStatus { get; set; }
        public decimal Limit { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public int PaymentDate { get; set; }

        public CreditCardEntity(Guid customerId, Guid cardId, CardType requestedCardType, CardStatus cardStatus, decimal limitApproved)
        {
            if (cardStatus == CardStatus.Denied)
            {
                CustomerId = customerId;
                CardId = cardId;
                CardType = requestedCardType;
                CardStatus = CardStatus.Denied;
            }

            if(cardStatus == CardStatus.Approved)
            {
                CustomerId = customerId;
                CardId = cardId;
                CardType = requestedCardType;
                CardStatus = CardStatus.Approved;
                CardExpirationDate = DateTime.UtcNow.AddYears(3);
                Limit = limitApproved;
                PaymentDate = 10;
            }
        }
    }
}
