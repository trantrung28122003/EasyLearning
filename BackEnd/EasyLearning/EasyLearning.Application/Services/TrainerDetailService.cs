using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public interface ITrannerDetailService
    {
        Task<TrainnerDetail> GetTrannerDetailById(string id);
        Task<List<TrainnerDetail>> GetAllTrannerDetails();
        Task CreateTrannerDetail(TrainnerDetail trannerDetail);
        Task UpdateTrannerDetail(TrainnerDetail trannerDetail);
        Task DeleteTrannerDetail(TrainnerDetail trannerDetail);
        Task SoftDeleteTrannerDetail(string id);
    }
    public class TrainerDetailService : ITrannerDetailService
    {
        private readonly TrainerDetailRepository _TrainerDetailRepository;
        public TrainerDetailService(TrainerDetailRepository trannerDetailRepository)
        {
            _TrainerDetailRepository = trannerDetailRepository;
        }
        public async Task<List<TrainnerDetail>> GetAllTrannerDetails() => await _TrainerDetailRepository.GetAll();
        public async Task<TrainnerDetail> GetTrannerDetailById(string id) => await _TrainerDetailRepository.GetById(id);
        public async Task CreateTrannerDetail(TrainnerDetail trannerDetail) => await _TrainerDetailRepository.Create(trannerDetail);
        public async Task UpdateTrannerDetail(TrainnerDetail trannerDetail) => await _TrainerDetailRepository.Update(trannerDetail);
        public async Task DeleteTrannerDetail(TrainnerDetail trannerDetail) => await _TrainerDetailRepository.Delete(trannerDetail);
        public async Task SoftDeleteTrannerDetail(string id) => await _TrainerDetailRepository.SoftDelete(id);
    }
}
