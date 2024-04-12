using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class ShoppingCartItemService
    {
        private readonly ShoppingCartItemRepository _shoppingCartItemRepository;
        public ShoppingCartItemService(ShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItem()
        {
            return await _shoppingCartItemRepository.GetAll();
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItemById(string id)
        {
            return await _shoppingCartItemRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            await _shoppingCartItemRepository.Create(shoppingCartItem);
        }

        public async Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            await _shoppingCartItemRepository.Update(shoppingCartItem);
        }

        public async Task DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            await _shoppingCartItemRepository.Delete(shoppingCartItem);
        }

        public async Task SoftDeleteShoppingCartItem(string id)
        {
            await _shoppingCartItemRepository.SoftDelete(id);
        }
    }
}
