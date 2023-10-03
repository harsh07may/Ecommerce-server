using Ecommerce_server.DTOs;
using Ecommerce_server.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //ACTION METHODS
        [HttpGet]
        
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            return await _orderService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderById(id);
            if (result is null)
            {
                return NotFound("Sorry, this order dosen't exist");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto newOrder)
        {
            var result = await _orderService.CreateOrder(newOrder);
            if (result is null)
                return NotFound("User/Product not found");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, OrderStatus orderStatus)
        {
            var result = await _orderService.UpdateOrder(id, orderStatus);
            if (result is null)
            {
                return NotFound("Sorry, this order dosen't exist");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (result is null)
            {
                return NotFound("Sorry, this order dosen't exist");
            }
            return Ok(result);
        }
    }
}
