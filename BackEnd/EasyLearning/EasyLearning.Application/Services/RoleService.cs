using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;
        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<UserRole>> GetRole()
        {
            return await _roleRepository.GetAll();
        }

        public async Task<List<UserRole>> GetRoleById(string id)
        {
            return await _roleRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateRole(UserRole role)
        {
            await _roleRepository.Create(role);
        }

        public async Task UpdateRole(UserRole role)
        {
            await _roleRepository.Update(role);
        }

        public async Task DeleteRole(UserRole role)
        {
            await _roleRepository.Delete(role);
        }

        public async Task SoftDeleteRole(string id)
        {
            await _roleRepository.SoftDelete(id);
        }
    }
}
