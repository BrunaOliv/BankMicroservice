using CustomerRegistration.Domain.Enums;

namespace CustomerRegistration.Domain.Entities
{
    public class Card
    {
        public int CardId { get; set; }  // card_id (chave primária)
        public int CustomerId { get; set; }  // customer_id (chave estrangeira)
        public string? CardType { get; set; }  // card_type (opcional)
        public decimal? RequestedLimit { get; set; }  // requested_limit (opcional)
        public decimal? RequestedCreditAmount { get; set; }  // requested_credit_amount (opcional)
        public int? PaymentTerm { get; set; }  // payment_term (opcional)
        public float? InterestRate { get; set; }  // interest_rate (opcional)
        public int? BranchNumber { get; set; }  // branch_number (opcional)
        public string? AccountNumber { get; set; }  // account_number (opcional)
        public StatusCard StatusCard { get; set; }
    }
}
