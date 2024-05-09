using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public interface ITrainerDetailService
    {
        Task<TrainerDetail> GetTranerDetailById(string id);
        Task<List<TrainerDetail>> GetAllTranerDetails();
        Task CreateTranerDetail(TrainerDetail trainerDetail);
        Task UpdateTranerDetail(TrainerDetail trainerDetail);
        Task DeleteTranerDetail(TrainerDetail trainerDetail);
        Task SoftDeleteTranerDetail(string id);
    }
    public class TrainerDetailService : ITrainerDetailService
    {
        private readonly TrainerDetailRepository _TrainerDetailRepository;
        public TrainerDetailService(TrainerDetailRepository trainerDetailRepository)
        {
            _TrainerDetailRepository = trainerDetailRepository;
        }
        public async Task<List<TrainerDetail>> GetAllTranerDetails() => await _TrainerDetailRepository.GetAll();
        public async Task<TrainerDetail> GetTranerDetailById(string id) => await _TrainerDetailRepository.GetById(id);
        public async Task CreateTranerDetail(TrainerDetail trainerDetail) => await _TrainerDetailRepository.Create(trainerDetail);
        public async Task UpdateTranerDetail(TrainerDetail trainerDetail) => await _TrainerDetailRepository.Update(trainerDetail);
        public async Task DeleteTranerDetail(TrainerDetail trainerDetail) => await _TrainerDetailRepository.Delete(trainerDetail);
        public async Task SoftDeleteTranerDetail(string id) => await _TrainerDetailRepository.SoftDelete(id);
    }
}
