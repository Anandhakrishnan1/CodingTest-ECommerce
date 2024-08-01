using Dapper;
using EcommerceApplication.Domain.Models;
using EcommerceApplication.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceApplication.DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDetailsResponseModel> GetOrderDetailsByCustomerId(string customerId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
        public IEnumerable<OrderDetailsResponseModel> GetOrderDetailsByCustomerId(string customerId)
        {
            using (var connection = CreateConnection())
            {
                var orderDetails = connection.Query<OrderDetailsResponseModel>(QueryConstants.GetOrderDetailsByCustomerId, new { @CustomerId = customerId });
                return orderDetails;
            }
        }
    }
}
