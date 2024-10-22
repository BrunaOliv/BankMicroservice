using CreditProposal.Domain.Enuns;

namespace CreditProposal.Domain.Entities
{
    public class CreditProposalEntity
    {
        private const int minimumScore = 250;
        public List<CreditCard> Cards  { get; set; }

        public CreditProposalEntity(int score, decimal monthlyIncome, int employmentDuration)
        {
            var creditProposal = GenerateCreditProposal(score,monthlyIncome, employmentDuration);
            Cards = creditProposal;
        }

        private List<CreditCard> GenerateCreditProposal(int score, decimal monthlyIncome, int employmentDuration)
        {
            var availableCards = new List<CreditCard>();

            if (monthlyIncome > 15000 &&  score >= minimumScore)
            {
                availableCards.Add(new CreditCard(CardType.Platinum, CalculateLimit(monthlyIncome, 5, score, employmentDuration)));
                availableCards.Add(new CreditCard(CardType.Gold, CalculateLimit(monthlyIncome, 3, score, employmentDuration)));
                availableCards.Add(new CreditCard(CardType.Silver, CalculateLimit(monthlyIncome, 2, score, employmentDuration)));
                return availableCards;
            }
            if (monthlyIncome >= 5000 && monthlyIncome <= 15000 &&  score >= minimumScore)
            {
                availableCards.Add(new CreditCard(CardType.Gold, CalculateLimit(monthlyIncome, 3, score, employmentDuration)));
                availableCards.Add(new CreditCard(CardType.Silver, CalculateLimit(monthlyIncome, 2, score, employmentDuration)));
                return availableCards;
            }
            if (monthlyIncome < 5000 &&  score >= minimumScore)
            {
                availableCards.Add(new CreditCard(CardType.Silver, CalculateLimit(monthlyIncome, 2, score, employmentDuration)));
                return availableCards;
            }            

            return availableCards;
        }

        private decimal CalculateLimit(decimal salary, decimal multiplier, int score, int employmentDuration)
        {
            decimal maxLimit = salary * multiplier;

            if (score >= 800 && employmentDuration >= 12)
                return maxLimit;
            else if (score >= 700 && employmentDuration >= 6)
                return maxLimit * 0.8m;
            else
                return maxLimit * 0.5m;
        }
    }
}
