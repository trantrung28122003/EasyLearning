using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(string id);
        Task<List<Order>> GetOrdersByUser();
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(Order order);
        Task SoftDeleteOrder(string id);
    }
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetAllOrders() => await _orderRepository.GetAll();
        public async Task<Order> GetOrderById(string id) => await _orderRepository.GetById(id);
        public async Task<List<Order>> GetOrdersByUser() => await _orderRepository.GetOrdersByUser();
        public async Task CreateOrder(Order order) => await _orderRepository.Create(order);
        public async Task UpdateOrder(Order order) => await _orderRepository.Update(order);
        public async Task DeleteOrder(Order order) => await _orderRepository.Delete(order);
        public async Task SoftDeleteOrder(string id) => await _orderRepository.SoftDelete(id);
    }
}
