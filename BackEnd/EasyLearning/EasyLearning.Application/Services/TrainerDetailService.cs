using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public interface ITrannerDetailService
    {
        Task<TrainerDetail> GetTranerDetailById(string id);
        Task<List<TrainerDetail>> GetAllTranerDetails();
        Task CreateTranerDetail(TrainerDetail trannerDetail);
        Task UpdateTranerDetail(TrainerDetail trannerDetail);
        Task DeleteTranerDetail(TrainerDetail trannerDetail);
        Task SoftDeleteTranerDetail(string id);
    }
    public class TrainerDetailService : ITrannerDetailService
    {
        private readonly TrainerDetailRepository _TrainerDetailRepository;
        public TrainerDetailService(TrainerDetailRepository trannerDetailRepository)
        {
            _TrainerDetailRepository = trannerDetailRepository;
        }
        public async Task<List<TrainerDetail>> GetAllTranerDetails() => await _TrainerDetailRepository.GetAll();
        public async Task<TrainerDetail> GetTranerDetailById(string id) => await _TrainerDetailRepository.GetById(id);
        public async Task CreateTranerDetail(TrainerDetail trannerDetail) => await _TrainerDetailRepository.Create(trannerDetail);
        public async Task UpdateTranerDetail(TrainerDetail trannerDetail) => await _TrainerDetailRepository.Update(trannerDetail);
        public async Task DeleteTranerDetail(TrainerDetail trannerDetail) => await _TrainerDetailRepository.Delete(trannerDetail);
        public async Task SoftDeleteTranerDetail(string id) => await _TrainerDetailRepository.SoftDelete(id);
    }
}
