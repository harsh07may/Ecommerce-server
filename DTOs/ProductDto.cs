namespace Ecommerce_server.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string ImgUrl { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
    }
}
