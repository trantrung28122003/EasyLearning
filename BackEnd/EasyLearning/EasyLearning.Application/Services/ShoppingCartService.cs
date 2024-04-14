using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCart>> GetAllShoppingCarts();
        Task<ShoppingCart> GetShoppingCartById(string id);
        Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId);
        Task CreateShoppingCart(ShoppingCart shoppingCart);
        Task UpdateShoppingCart(ShoppingCart shoppingCart);
        Task DeleteShoppingCart(ShoppingCart shoppingCart);
        Task SoftDeleteShoppingCart(string id);
    }
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(ShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<List<ShoppingCart>> GetAllShoppingCarts() => await _shoppingCartRepository.GetAll();
        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId) => await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);
        public async Task<ShoppingCart>GetShoppingCartById(string id) => await _shoppingCartRepository.GetById(id);
        public async Task CreateShoppingCart(ShoppingCart shoppingCart) => await _shoppingCartRepository.Create(shoppingCart);
        public async Task UpdateShoppingCart(ShoppingCart shoppingCart) => await _shoppingCartRepository.Update(shoppingCart);
        public async Task DeleteShoppingCart(ShoppingCart shoppingCart) => await _shoppingCartRepository.Delete(shoppingCart);
        public async Task SoftDeleteShoppingCart(string id) => await _shoppingCartRepository.SoftDelete(id);
    }
}
