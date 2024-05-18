using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IUserTrainingProgressService
    {
        Task<List<UserTrainingProgress>> GetAllUserTrainingProgress();
        Task<UserTrainingProgress> GetUserTrainingProgressById(string UserTrainingProgressId);
        Task<List<UserTrainingProgress>> GetUserTrainingProgressByTrainingPartId(string trainingPartId);
        Task<List<UserTrainingProgress>> GetUserTrainingProgressByUserId(string userId);
        Task<UserTrainingProgress> GetUserTrainingProgressByTrainingPartIdAndUserId(string trainingPartId, string userId);
        Task CreateUserTrainingProgress(UserTrainingProgress userTrainingProgress);
        Task UpdateUserTrainingProgress(UserTrainingProgress userTrainingProgress);
        Task DeleteUserTrainingProgress(UserTrainingProgress userTrainingProgress);
        Task SoftDeleteUserTrainingProgress(string UserTrainingProgressId);
    }

    public class UserTrainingProgressService : IUserTrainingProgressService
    {
        private readonly UserTrainingProgressRepository _userTrainingProgressRepository;
        public UserTrainingProgressService(UserTrainingProgressRepository userTrainingProgressRepository)
        {
            _userTrainingProgressRepository = userTrainingProgressRepository;
        }

        public async Task<List<UserTrainingProgress>> GetAllUserTrainingProgress() => await _userTrainingProgressRepository.GetAll();
        public async Task<UserTrainingProgress> GetUserTrainingProgressById(string userTrainingProgressId) => await _userTrainingProgressRepository.GetById(userTrainingProgressId);
        public async Task<List<UserTrainingProgress>> GetUserTrainingProgressByTrainingPartId(string trainingPartId) => await _userTrainingProgressRepository.GetByCondition(s => s.TrainingPartId == trainingPartId);
        public async Task<List<UserTrainingProgress>> GetUserTrainingProgressByUserId(string userId) => await _userTrainingProgressRepository.GetByCondition(s => s.UserId == userId);
        public async Task<UserTrainingProgress> GetUserTrainingProgressByTrainingPartIdAndUserId(string trainingPartId, string userId) => await _userTrainingProgressRepository.GetUserTrainingProgressByTrainingPartIdAndUserId(trainingPartId, userId);
        public async Task CreateUserTrainingProgress(UserTrainingProgress userTrainingProgress) => await _userTrainingProgressRepository.Create(userTrainingProgress);
        public async Task UpdateUserTrainingProgress(UserTrainingProgress userTrainingProgress) => await _userTrainingProgressRepository.Update(userTrainingProgress);
        public async Task DeleteUserTrainingProgress(UserTrainingProgress userTrainingProgress) => await _userTrainingProgressRepository.Delete(userTrainingProgress);
        public async Task SoftDeleteUserTrainingProgress(string id) => await _userTrainingProgressRepository.SoftDelete(id);


    }
}
