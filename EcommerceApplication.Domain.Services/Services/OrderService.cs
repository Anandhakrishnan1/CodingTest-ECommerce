using EcommerceApplication.DataAccess.Repository;
using EcommerceApplication.Domain.Models;

namespace EcommerceApplication.Domain.Services.Services
{
    public interface IOrderService
    {
        OrderResponse GetOrderDetailsByCustomerId(string customerId);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public OrderResponse GetOrderDetailsByCustomerId(string customerId)
        {
            var orders = _orderRepository.GetOrderDetailsByCustomerId(customerId);
            var orderResponse = new OrderResponse();
            orderResponse.Customer = new Customer
            {
                FirstName = orders.FirstOrDefault().FirstName,
                LastName = orders.FirstOrDefault().LastName
            };

            var latestOrder = orders.FirstOrDefault();
            if (latestOrder != null)
            {
                orderResponse.Order = new Order
                {
                    DeliveryAddress = latestOrder.DeliveryAddress,
                    OrderDate = latestOrder.OrderDate,
                    DeliveryExpected = latestOrder.DeliveryExpected,
                    OrderNumber = latestOrder.OrderId
                };

                orderResponse.Order.OrderItems = orders.Select(x => new OrderItem
                {
                    Product = x.ProductName,
                    Quantity = x.Quantity,
                    PriceEach = x.Price
                }).ToList();
            }
            return orderResponse;
        }
    }
}
