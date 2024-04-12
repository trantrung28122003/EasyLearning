using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetOrder()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<List<Order>> GetOrderById(string id)
        {
            return await _orderRepository.GetByCondition(s=> s.Id == id);
        }

        public async Task CreateOrder(Order order)
        {
            await _orderRepository.Create(order);
        }

        public async Task UpdateOrder(Order order)
        {
            await _orderRepository.Update(order);
        }

        public async Task DeleteOrder(Order order)
        {
            await _orderRepository.Delete(order);
        }

        public async Task SoftDeleteOrder(string id)
        {
            await _orderRepository.SoftDelete(id);
        }
    }
}
