using CustomerRegistration.Domain.Enums;

namespace CustomerRegistration.Domain.Entities
{
    public class Card
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string? CardType { get; set; }
        public decimal? RequestedLimit { get; set; }
        public decimal? RequestedCreditAmount { get; set; }
        public int? PaymentTerm { get; set; }
        public float? InterestRate { get; set; }
        public int? BranchNumber { get; set; }
        public string? AccountNumber { get; set; } 
        public StatusCard StatusCard { get; set; }
    }
}
