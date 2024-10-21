using CreditProposal.Domain.Enuns;

namespace CreditProposal.Domain.Entities
{
    public class CreditCard
    {
        public Guid CardId { get; set; }
        public CardType CardType { get; set; }
        public decimal MaxLimit { get; set; }

        public CreditCard(CardType cardType, decimal maxLimit)
        {
            CardType = cardType;
            MaxLimit = maxLimit; 
        }
    }
}
