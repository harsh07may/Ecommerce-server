using Ecommerce_server.DTOs;

namespace Ecommerce_server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetProductById(int id);
        Task<Product> CreateProduct(ProductDto newProduct);
        Task<List<Product>?> UpdateProduct(int id, Product newProduct);
        Task<List<Product>?> DeleteProduct(int id);
    }
}
