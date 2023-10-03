using AutoMapper;
using Ecommerce_server.DTOs;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce_server.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> CreateProduct(ProductDto newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            var dbproducts = await _context.Products.ToListAsync();
            return dbproducts;
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return null;

            return product;
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {
            var updatedProduct = await _context.Products.FindAsync(id);

            if (updatedProduct is null)
                return null;

            updatedProduct.Name = request.Name;
            updatedProduct.Description = request.Description;
            updatedProduct.Price = request.Price;

            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
    }
}
