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
            MaxLimit = maxLimit; 
        }
    }
}
