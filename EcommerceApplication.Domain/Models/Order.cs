namespace EcommerceApplication.Domain.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public DateTime DeliveryExpected { get; set; }
    }
}
