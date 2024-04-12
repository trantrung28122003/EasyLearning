using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
namespace EasyLearning.Application.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategory()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<List<Category>> GetCategoryById(string id)
        {
            return await _categoryRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateCategory(Category category)
        {
            await _categoryRepository.Create(category);
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public async Task DeleteCategory(Category category)
        {
            await _categoryRepository.Delete(category);
        }

        public async Task SoftDeleteCategory(string id)
        {
            await _categoryRepository.SoftDelete(id);
        }
    }
}
