using CustomerRegistration.Domain.Entities;
using CustomerRegistration.Domain.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CustomerRegistration.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");

        public async Task<Guid> CreateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var insertCustomerSql = @"
                            INSERT INTO Customers (FullName, BirthDate, Cpf, Rg, IssuingAuthority, Gender, Nationality, MaritalStatus) 
                            OUTPUT inserted.CustomerId
                            VALUES (@FullName, @BirthDate, @Cpf, @Rg, @IssuingAuthority, @Gender, @Nationality, @MaritalStatus);";

                        var customerId = await connection.ExecuteScalarAsync<Guid>(insertCustomerSql, customer, transaction);

                        customer.Contact.CustomerId = customerId;
                        var insertContactSql = @"
                            INSERT INTO Contacts (CustomerId, Phone, Email) 
                            VALUES (@CustomerId, @Phone, @Email);";
                        await connection.ExecuteAsync(insertContactSql, customer.Contact, transaction);

                        customer.Address.CustomerId = customerId;
                        var insertAddressSql = @"
                            INSERT INTO Addresses (CustomerId, Street, Number, Neighborhood, City, State, PostalCode) 
                            VALUES (@CustomerId, @Street, @Number, @Neighborhood, @City, @State, @PostalCode);";
                        await connection.ExecuteAsync(insertAddressSql, customer.Address, transaction);

                        customer.FinancialInformation.CustomerId = customerId;
                        var insertFinancialInfoSql = @"
                            INSERT INTO FinancialInformation (CustomerId, MonthlyIncome, Occupation, CompanyName, EmploymentDuration, CreditScore) 
                            VALUES (@CustomerId, @MonthlyIncome, @Occupation, @CompanyName, @EmploymentDuration, @CreditScore);";
                        await connection.ExecuteAsync(insertFinancialInfoSql, customer.FinancialInformation, transaction);

                        foreach (var card in customer.Cards)
                        {
                            card.CustomerId = customerId;

                            var insertCardSql = @"
                                INSERT INTO CreditCards (CustomerId, CardType, CardStatus, PaymentDate) 
                                VALUES (@CustomerId, @CardType, @CardStatus, @PaymentDate);";
                            await connection.ExecuteAsync(insertCardSql, card, transaction);
                        }

                        transaction.Commit();

                        return customerId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }



            }
        }

        public async Task UpdateCustomerCreditCard(List<Card> cards)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var updateCardSql = @"
                    UPDATE CreditCards 
                    SET 
                        CardStatus = @CardStatus,
                        PaymentDate = @PaymentDate,
                        Limit = @Limit,
                        CardExpirationDate = @CardExpirationDate
                    WHERE 
                        CardId = @CardId;";

                foreach (var card in cards)
                {
                    await connection.ExecuteAsync(updateCardSql, new
                    {
                        card.CustomerId,
                        card.CardType,
                        card.CardStatus,
                        card.PaymentDate,
                        card.Limit,
                        card.CardExpirationDate,
                        card.CardId
                    });
                }
            }
        }

        public async Task<List<Card>> GetCustomerCreditCardsAsync(Guid customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"
                    SELECT 
                        cc.CustomerId, 
                        cc.CardId, 
                        cc.CardType, 
                        cc.CardStatus, 
                        cc.PaymentDate, 
                        cc.Limit, 
                        cc.CardExpirationDate
                    FROM 
                        CreditCards cc
                    INNER JOIN 
                        Customers c ON cc.CustomerId = c.CustomerId
                    WHERE 
                        c.CustomerId = @CustomerId";

                var result = await connection.QueryAsync<Card>(
                    sql,
                    new { CustomerId = customerId }
                );

                return result.ToList();
            }
        }
    }
}
