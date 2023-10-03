namespace Ecommerce_server.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();

    }
}
