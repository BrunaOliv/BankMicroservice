using CreditProposal.Domain.Enuns;

namespace CreditProposal.Domain.Entities
{
    public class CreditCard
    {
        private const decimal maxLimitGoldCard = 15000;
        private const decimal maxLimitSilverCard = 10000;
        public CardType CardType { get; set; }
        public decimal MaxLimit { get; set; }

        public CreditCard(CardType cardType, decimal maxLimit)
        {
            CardType = cardType;
            MaxLimit = SetLimit(maxLimit, cardType); 
        }

        private decimal SetLimit(decimal maxLimit, CardType cardType)
        {
            if(cardType == CardType.Gold)
            {
                if (maxLimit >= maxLimitGoldCard)
                    return maxLimitGoldCard;
            }

            if (cardType == CardType.Silver)
            {
                if (maxLimit >= maxLimitSilverCard)
                    return maxLimitSilverCard;
            }

            return maxLimit;
        }
    }
}
