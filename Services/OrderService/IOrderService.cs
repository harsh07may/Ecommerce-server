using Ecommerce_server.DTOs;

namespace Ecommerce_server.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order?> GetOrderById(int id);
        Task<Order> CreateOrder(OrderDto newOrder);
        Task<Order> UpdateOrder(int id,OrderStatus orderStatus);
        Task<List<Order>?> DeleteOrder(int id);
    }
}
