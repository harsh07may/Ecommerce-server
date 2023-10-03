using System.Text.Json.Serialization;

namespace Ecommerce_server.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }

    }
}
