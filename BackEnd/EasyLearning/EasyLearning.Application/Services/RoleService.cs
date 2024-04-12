using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IRoleService
    {
        Task<List<UserRole>> GetAllRoles();
        Task<UserRole> GetRoleById(string id);
        Task CreateRole(UserRole role);
        Task UpdateRole(UserRole role);
        Task DeleteRole(UserRole role);
        Task SoftDeleteRole(string id);
    }
    public class RoleService : IRoleService
    {
        private readonly RoleRepository _roleRepository;
        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<UserRole>> GetAllRoles() => await _roleRepository.GetAll();
        public async Task<UserRole> GetRoleById(string id) => await _roleRepository.GetById(id);
        public async Task CreateRole(UserRole role) => await _roleRepository.Create(role);
        public async Task UpdateRole(UserRole role) => await _roleRepository.Update(role);
        public async Task DeleteRole(UserRole role) => await _roleRepository.Delete(role);
        public async Task SoftDeleteRole(string id) => await _roleRepository.SoftDelete(id);
    }
}
