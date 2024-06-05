using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Repostiory;

using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
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
        private readonly IPaymentService _paymentService;
        private readonly UserRepository _userRepository;
        public OrderController(ICourseService courseService, IShoppingCartService shoppingCartService,
            IShoppingCartItemService shoppingCartItemService, IOrderService orderService, 
            IOrderDetailService orderDetailService, UserRepository userRepository, IPaymentService paymentService)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
            _courseService = courseService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _userRepository = userRepository;
            _paymentService = paymentService;
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
            
            
            TempData["OrderViewModelJson"] = JsonConvert.SerializeObject(orderViewModel);
            return RedirectToAction("Index", "Payment");
        }
    }
}
