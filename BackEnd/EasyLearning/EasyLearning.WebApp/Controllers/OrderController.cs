using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace EasyLearning.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly UserRepository _userRepository;
        public OrderController(ICourseService courseService, IShoppingCartService shoppingCartService,
            IShoppingCartItemService shoppingCartItemService, IOrderService orderService, 
            IOrderDetailService orderDetailService, UserRepository userRepository)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
            _courseService = courseService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Create()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var getShoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
            decimal totalPrice = 0;
            foreach (var item in getShoppingCartItem)
            {
                totalPrice += item.CartItemPrice.Value;
            }
            var orderViewModel = new OrderViewModel
            {
                OrderTotalPrice = totalPrice,
                UserId = _userRepository.getCurrrentUser(),
                ShoppingCartItems = getShoppingCartItem,
            };
           
            return View(orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel orderViewModel)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
             var getShoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
           
            var order = new Order
            {
                OrderPaymentMethod = orderViewModel.OrderPaymentMethod,
                OrderNotes = orderViewModel.OrderNotes,
                DateCreate = DateTime.Now,
                IsDeleted = false
            };
            await _orderService.CreateOrder(order);

            foreach (var itemShoppingCart in getShoppingCartItem)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    CoursesId = itemShoppingCart.CoursesId,
                    DateCreate = DateTime.Now,
                    IsDeleted = false
                };
                await _orderDetailService.CreateOrderDetail(orderDetail);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
