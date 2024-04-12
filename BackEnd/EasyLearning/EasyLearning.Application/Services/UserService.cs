using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUser()
        {
            return await _userRepository.GetAll();
        }

        public async Task<List<User>> GetUserByCondition(string id)
        {
            return await _userRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }
        public async Task DeleteUser(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task SoftDeleteUser(string id)
        {
            await _userRepository.SoftDelete(id);
        }
    }
}
