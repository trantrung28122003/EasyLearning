using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;
namespace EasyLearning.Application.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task SoftDeleteCategory(string id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> GetAllCategories() => await _categoryRepository.GetAll();
        public async Task<Category> GetCategoryById(string id) => await _categoryRepository.GetById(id);
        public async Task CreateCategory(Category category) => await _categoryRepository.Create(category);
        public async Task UpdateCategory(Category category) => await _categoryRepository.Update(category);
        public async Task DeleteCategory(Category category) => await _categoryRepository.Delete(category);
        public async Task SoftDeleteCategory(string id) => await _categoryRepository.SoftDelete(id);

    }
}
