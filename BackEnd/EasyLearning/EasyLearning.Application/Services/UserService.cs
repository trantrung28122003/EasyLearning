using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers(); 
        Task<User> GetUserById(string id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task SoftDeleteUser(string id);
    }
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetAllUsers() => await _userRepository.GetAll();
        public async Task<User> GetUserById(string id) => await _userRepository.GetById(id);
        public async Task CreateUser(User user) => await _userRepository.Create(user);
        public async Task UpdateUser(User user) => await _userRepository.Update(user);
        public async Task DeleteUser(User user) => await _userRepository.Delete(user);
        public async Task SoftDeleteUser(string id) => await _userRepository.SoftDelete(id);
    }
}
