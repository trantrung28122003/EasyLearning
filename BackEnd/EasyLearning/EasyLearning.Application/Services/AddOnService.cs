using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class AddOnService
    {
        private readonly AddOnRepository _addOnRepository;
        public AddOnService(AddOnRepository addOnRepository)
        {
            _addOnRepository = addOnRepository;
        }

        public async Task<List<AddOn>> GetAddOn()
        {
            return await _addOnRepository.GetAll();
        }

        public async Task<List<AddOn>> GetOnById(string id)
        {
            return await _addOnRepository.GetByCondition(s=>s.Id == id);
        }
        public async Task CreateAddOn(AddOn addOn)
        {
            await _addOnRepository.Create(addOn);
        }

        public async Task UpdateAddOn(AddOn addOn)
        {
            await _addOnRepository.Update(addOn);
        }

        public async Task DeleteAddOn(AddOn addOn)
        {
            await _addOnRepository.Delete(addOn);
        }

        public async Task SoftDeleteAddOn(string id)
        {
            await _addOnRepository.SoftDelete(id);
        }
    }
}
