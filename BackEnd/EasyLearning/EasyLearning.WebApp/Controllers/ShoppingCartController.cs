using AutoMapper;
using EasyLearning.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        public ShoppingCartController(IShoppingCartService shoppingCartService, IShoppingCartItemService shoppingCartItemService)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
  
        }

        public async Task<ActionResult> GetShoppingCart()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync("User1");
            var shoppingCartItem = await _shoppingCartItemService
            if (shoppingCart == null)
            {
                return NotFound("Shopping cart not found.");
            }
            return Ok(shoppingCart);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
