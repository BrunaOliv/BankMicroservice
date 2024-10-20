using CreditProposal.Domain.Enuns;

namespace CreditProposal.Domain.Entities
{
    public class CreditProposalEntity
    {
        public List<CreditCard> Cards  { get; set; }

        public CreditProposalEntity(int score, decimal monthlyIncome, int employmentDuration, CardType cardType)
        {
            var creditProposal = GenerateCreditProposal(score,monthlyIncome, employmentDuration, cardType);
            Cards = creditProposal;
        }

        private List<CreditCard> GenerateCreditProposal(int score, decimal monthlyIncome, int employmentDuration, CardType cardType)
        {
            var availableCards = new List<CreditCard>();

            if (monthlyIncome > 15000 && employmentDuration >= 6 && score >= 600)
            {
                availableCards.Add(new CreditCard(CardType.Platinum, CalculateLimit(monthlyIncome, 5, score)));
                availableCards.Add(new CreditCard(CardType.Gold, CalculateLimit(monthlyIncome, 3, score)));
                availableCards.Add(new CreditCard(CardType.Silver, CalculateLimit(monthlyIncome, 2, score)));
            }
            if (monthlyIncome >= 5000 && monthlyIncome <= 15000 && employmentDuration >= 12 && score >= 600)
            {
                availableCards.Add(new CreditCard(CardType.Gold, CalculateLimit(monthlyIncome, 3, score)));
                availableCards.Add(new CreditCard(CardType.Silver, CalculateLimit(monthlyIncome, 2, score)));
            }
            if (monthlyIncome < 5000 && employmentDuration >= 18 && score >= 600)
            {
                availableCards.Add(new CreditCard(CardType.Silver, CalculateLimit(monthlyIncome, 2, score)));
            }
            if(!availableCards.Any())
            {
                var availableCard = new CreditCard(CardType.None, 0);
                availableCards.Add(availableCard);
            }
            

            return availableCards;
        }

        private decimal CalculateLimit(decimal salary, decimal multiplier, int score)
        {
            decimal maxLimit = salary * multiplier;

            if (score >= 800)
                return maxLimit;
            else if (score >= 700)
                return maxLimit * 0.8m;
            else
                return maxLimit * 0.5m;
        }
    }
}
