using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;
using EasyLearning.Infrastructure.Data.Repository;

namespace EasyLearning.Application.Services
{
    public interface ITrainerDetailService
    {
        Task<TrainerDetail> GetTrainerDetailById(string id);
        Task<List<TrainerDetail>> GetAllTrainerDetails();
        Task CreateTrainerDetail(TrainerDetail trainerDetail);
        Task UpdateTrainerDetail(TrainerDetail trainerDetail);
        Task DeleteTrainerDetail(TrainerDetail trainerDetail);
        Task SoftDeleteTrainerDetail(string id);
    }
    public class TrainerDetailService : ITrainerDetailService
    {
        private readonly TrainerDetailRepository _TrainerDetailRepository;
        public TrainerDetailService(TrainerDetailRepository trainerDetailRepository)
        {
            _TrainerDetailRepository = trainerDetailRepository;
        }
        public async Task<List<TrainerDetail>> GetAllTrainerDetails() => await _TrainerDetailRepository.GetAll();
        public async Task<TrainerDetail> GetTrainerDetailById(string id) => await _TrainerDetailRepository.GetById(id);
        public async Task CreateTrainerDetail(TrainerDetail trainerDetail) => await _TrainerDetailRepository.Create(trainerDetail);
        public async Task UpdateTrainerDetail(TrainerDetail trainerDetail) => await _TrainerDetailRepository.Update(trainerDetail);
        public async Task DeleteTrainerDetail(TrainerDetail trainerDetail) => await _TrainerDetailRepository.Delete(trainerDetail);
        public async Task SoftDeleteTrainerDetail(string id) => await _TrainerDetailRepository.SoftDelete(id);
    }
}
