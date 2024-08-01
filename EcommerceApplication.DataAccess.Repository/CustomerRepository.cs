using Dapper;
using EcommerceApplication.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceApplication.DataAccess.Repository
{
    public interface ICustomerRepository
    {
        bool CheckIsCustomerValidByEmailAndCustomerId(string emailId, string customerId);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private IConfiguration _configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
        public bool CheckIsCustomerValidByEmailAndCustomerId(string emailId, string customerId)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var customers = connection.QueryFirstOrDefault<bool>(QueryConstants.CheckCustomerData, new { @CustomerId = customerId, @Email = emailId });

                return customers;
            }
        }
    }
}
