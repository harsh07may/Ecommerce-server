using AutoMapper;
using Ecommerce_server.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return null;

            return order;
        }
        public async Task<Order> CreateOrder(OrderDto newOrder)
        {

            var user = await _context.Users.FindAsync(newOrder.UserId);
            if (user is null)
                return null;

            Order order = new()
            {
                UserId = newOrder.UserId
            };
            foreach (var item in newOrder.ProductIds)
            {
                var product = await _context.Products.FindAsync(item);
                if (product is null)
                    return null;

                OrderItem orderItem = new()
                {
                    Order = order,
                    Product = product
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrder(int id, OrderStatus orderStatus)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return null;

            order.Status = orderStatus;
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>?> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null)
                return null;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return await _context.Orders.ToListAsync();
        }

    }
}
