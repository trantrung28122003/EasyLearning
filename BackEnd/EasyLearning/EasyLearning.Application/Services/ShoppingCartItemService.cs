using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IShoppingCartItemService
    {
        Task<List<ShoppingCartItem>> GetAllShoppingCartItems();
        Task<ShoppingCartItem> GetShoppingCartItemById(string id);
        Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem);
        Task SoftDeleteShoppingCartItem(string id);
    }
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly ShoppingCartItemRepository _shoppingCartItemRepository;
        public ShoppingCartItemService(ShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<List<ShoppingCartItem>> GetAllShoppingCartItems() => await _shoppingCartItemRepository.GetAll();
        public async Task<ShoppingCartItem> GetShoppingCartItemById(string id) => await _shoppingCartItemRepository.GetById(id);
        public async Task CreateShoppingCartItem(ShoppingCartItem shoppingCartItem) => await _shoppingCartItemRepository.Create(shoppingCartItem);
        public async Task UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem) => await _shoppingCartItemRepository.Update(shoppingCartItem);
        public async Task DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem) => await _shoppingCartItemRepository.Delete(shoppingCartItem);
        public async Task SoftDeleteShoppingCartItem(string id) => await _shoppingCartItemRepository.SoftDelete(id);
    }
}
