using System.Text.Json.Serialization;

namespace Ecommerce_server.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4
    }
}
