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
    public interface IAddOnService
    {
        Task<List<AddOn>> GetAllAddOns();
        Task<AddOn> GetAddOnById(string id);
        Task CreateAddOn(AddOn addOn);
        Task UpdateAddOn(AddOn addOn);
        Task DeleteAddOn(AddOn addOn);
        Task SoftDeleteAddOn(string id);

    }
    public class AddOnService : IAddOnService
    {
        private readonly AddOnRepository _addOnRepository;
        public AddOnService(AddOnRepository addOnRepository)
        {
            _addOnRepository = addOnRepository;
        }
        public async Task<List<AddOn>> GetAllAddOns() => await _addOnRepository.GetAll();
        public async Task<AddOn> GetAddOnById(string id) => await _addOnRepository.GetById(id);
        public async Task CreateAddOn(AddOn addOn) => await _addOnRepository.Create(addOn);
        public async Task UpdateAddOn(AddOn addOn) => await _addOnRepository.Update(addOn);
        public async Task DeleteAddOn(AddOn addOn) => await _addOnRepository.Delete(addOn);
        public async Task SoftDeleteAddOn(string id) => await _addOnRepository.SoftDelete(id);
    }
}
