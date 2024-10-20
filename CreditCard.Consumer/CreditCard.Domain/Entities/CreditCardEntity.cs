using CreditCard.Domain.Enuns;

namespace CreditCard.Domain.Entities
{
    public class CreditCardEntity
    {
        //private const decimal maxLimitGoldCard = 15000;
        //private const decimal maxLimitSilverCard = 10000;
        public int CustomerId { get; set; }
        public CardType CardType { get; set; }
        public CardStatus CardStatus { get; set; }
        public decimal Limit { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public int PaymentDate { get; set; }

        public CreditCardEntity(int customerId, CardType requestedCardType, CardStatus cardStatus, decimal limitApproved)
        {
            if (cardStatus == CardStatus.Denied)
            {
                CustomerId = customerId;
                CardType = requestedCardType;
                CardStatus = CardStatus.Denied;
            }

            if(cardStatus == CardStatus.Approved)
            {
                CustomerId = customerId;
                CardType = requestedCardType;
                CardStatus = CardStatus.Approved;
                CardExpirationDate = DateTime.UtcNow.AddYears(3);
                Limit = limitApproved;
                PaymentDate = 10;
            }
        }

        //private decimal SetLimit(decimal maxLimit, CardType cardType)
        //{
        //    if (cardType == CardType.Gold)
        //    {
        //        if (maxLimit >= maxLimitGoldCard)
        //            return maxLimitGoldCard;
        //    }

        //    if (cardType == CardType.Silver)
        //    {
        //        if (maxLimit >= maxLimitSilverCard)
        //            return maxLimitSilverCard;
        //    }

        //    return maxLimit;
        //}
    }
}
