using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public class ShoppingCartService
    {
        private readonly ShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(ShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<List<ShoppingCart>> GetShoppingCart()
        {
            return await _shoppingCartRepository.GetAll();
        }

        public async Task<List<ShoppingCart>> GetShoppingCartByCondition(string id)
        {
            return await _shoppingCartRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateShoppingCart(ShoppingCart shoppingCart)
        {
            await _shoppingCartRepository.Create(shoppingCart);
        }

        public async Task UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            await _shoppingCartRepository.Update(shoppingCart);
        }

        public async Task DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            await _shoppingCartRepository.Delete(shoppingCart);
        }

        public async Task SoftDeleteShoppingCart(string id)
        {
            await _shoppingCartRepository.SoftDelete(id);
        }
    }
}
