﻿using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;

namespace EasyLearning.Application.Services
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetails();   
        Task<OrderDetail> GetOrderDetailById(string id);
        Task<List<OrderDetail>> GetOrderDetailByOrder(string OrderId);
        Task CreateOrderDetail(OrderDetail orderDetail);
        Task UpdateOrderDetail(OrderDetail orderDetail);
        Task DeleteOrderDetail(OrderDetail orderDetail);
        Task SoftDeleteOrderDetail(string id);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly OrderDetailRepository _orderDetailRepository;
        public OrderDetailService(OrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<List<OrderDetail>> GetAllOrderDetails() => await _orderDetailRepository.GetAll();
        public async Task<OrderDetail>GetOrderDetailById(string id) => await _orderDetailRepository.GetById(id);
        public async Task<List<OrderDetail>> GetOrderDetailByOrder(string orderId) => await _orderDetailRepository.GetByCondition(s=>s.OrderId == orderId);
        public async Task CreateOrderDetail(OrderDetail orderDetail) => await _orderDetailRepository.Create(orderDetail);
        public async Task UpdateOrderDetail(OrderDetail orderDetail) => await _orderDetailRepository.Update(orderDetail);
        public async Task DeleteOrderDetail(OrderDetail orderDetail) => await _orderDetailRepository.Delete(orderDetail);
        public async Task SoftDeleteOrderDetail(string id) => await _orderDetailRepository.SoftDelete(id);
    }   
}
