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

        public async Task<int> CreateCustomer(Customer customer)
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
                            VALUES (@FullName, @BirthDate, @Cpf, @Rg, @IssuingAuthority, @Gender, @Nationality, @MaritalStatus);
                            SELECT CAST(SCOPE_IDENTITY() AS int);";

                        var customerId = await connection.ExecuteScalarAsync<int>(insertCustomerSql, customer, transaction);

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

                        foreach(var card in customer.Cards)
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
    }
}
