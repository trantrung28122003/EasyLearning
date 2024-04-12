using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class OrderDetailService
    {
        private readonly OrderDetailRepository _orderDetailRepository;
        public OrderDetailService(OrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetOrderDetail()
        {
            return await _orderDetailRepository.GetAll();
        }

        public async Task<List<OrderDetail>> GetOrderDetailById(string id)
        {
            return await _orderDetailRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateOrderDetail(OrderDetail orderDetail)
        {
             await _orderDetailRepository.Create(orderDetail);
        }

        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            await _orderDetailRepository.Update(orderDetail);
        }

        public async Task DeleteOrderDetail(OrderDetail orderDetail)
        {
            await _orderDetailRepository.Delete(orderDetail);
        }

        public async Task SoftDeleteOrderDetail(string id)
        {
            await _orderDetailRepository.SoftDelete(id);
        }
    }
}
