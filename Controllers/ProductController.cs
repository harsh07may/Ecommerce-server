using Ecommerce_server.DTOs;
using Ecommerce_server.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //DEPENPENCY INJECTION
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //ACTION METHODS
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            if (result is null)
            {
                return NotFound("Sorry, this product dosen't exist");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDto newProduct)
        {
            var result = await _productService.CreateProduct(newProduct);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product request)
        {
            var result = await _productService.UpdateProduct(id, request);
            if (result is null)
            {
                return NotFound("Sorry, this product dosen't exist");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result is null)
            {
                return NotFound("Sorry, this product dosen't exist");
            }
            return Ok(result);
        }

    }
}
