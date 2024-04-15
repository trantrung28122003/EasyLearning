using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public ShoppingCartController(ICourseService courseService, IShoppingCartService shoppingCartService, IShoppingCartItemService shoppingCartItemService)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
            _courseService = courseService;
        }

        public async Task<ActionResult> GetShoppingCart()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var shoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart("7367c551 - 5ba0 - 4a28 - 9268 - 218caeae9759");
            if (shoppingCartItem == null)
            {
                return NotFound("Shopping cart not found.");
            }
            return View(shoppingCartItem);
        }
   

        
        public async Task<ActionResult> AddToCart(string courseId)
        {
            var getCourse = await _courseService.GetCourseById(courseId);
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var shoppingCartItem = new ShoppingCartItem()
            {
                CartItemName = getCourse.CoursesName,
                CartItemPrice = getCourse.CoursesPrice,
                ImageUrl = "aaa",
                CoursesId = getCourse.Id,
                ShoppingCartId = shoppingCart.Id,
            };
            await _shoppingCartItemService.CreateShoppingCartItem(shoppingCartItem);
            return RedirectToAction("GetShoppingCart");
        }
        

    }
}
