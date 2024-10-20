using CreditCard.Domain.Entities;
using CreditCard.Domain.Enuns;

namespace CreditCard.Application.DTOs
{
    public class CreditCardMessage
    {
        public CreditCardMessage(int customerId, List<CreditCardEntity> allCards)
        {
            CustomerId = customerId;
            CreditCards = allCards
                .Select(card => new CreditCard
                {
                    CardType = card.CardType,
                    CardStatus = card.CardStatus,
                    Limit = card.Limit,
                    CardExpirationDate = card.CardExpirationDate,
                    PaymentDate = card.PaymentDate,

                }).ToList();
        }

        public int CustomerId { get; set; }
        public List<CreditCard> CreditCards { get; set; }

        public class CreditCard
        {
            public CardType CardType { get; set; }
            public CardStatus CardStatus { get; set; }
            public decimal Limit { get; set; }
            public DateTime CardExpirationDate { get; set; }
            public int PaymentDate { get; set; }
        }
    }
}
