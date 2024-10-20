namespace CustomerRegistration.Domain.Entities
{
    public class FinancialInformation
    {
        public int FinancialInfoId { get; set; }
        public int CustomerId { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public string? Occupation { get; set; }
        public string? CompanyName { get; set; }
        public int? EmploymentDuration { get; set; }
        public int? CreditScore { get; set; }
    }
}
