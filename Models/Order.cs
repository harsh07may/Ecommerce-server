using System.Text.Json.Serialization;

namespace Ecommerce_server.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        [JsonIgnore]
        public User? User { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}
