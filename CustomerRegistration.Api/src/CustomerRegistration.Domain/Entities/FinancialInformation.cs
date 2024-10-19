namespace CustomerRegistration.Domain.Entities
{
    public class FinancialInformation
    {
        public int FinancialInfoId { get; set; }  // financial_info_id (chave primária)
        public int CustomerId { get; set; }  // customer_id (chave estrangeira)
        public decimal? MonthlyIncome { get; set; }  // monthly_income (opcional)
        public string? Occupation { get; set; }  // occupation (opcional)
        public string? CompanyName { get; set; }  // company_name (opcional)
        public int? EmploymentDuration { get; set; }  // employment_duration (opcional)
        public int? CreditScore { get; set; }  // credit_score (opcional)
    }
}
