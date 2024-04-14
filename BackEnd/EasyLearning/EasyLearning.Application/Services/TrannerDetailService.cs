using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class TrannerDetailService : ITrannerDetailService
    {
        private readonly TrannerDetailRepository _trannerDetailRepository;
        public TrannerDetailService(TrannerDetailRepository trannerDetailRepository)
        {
            _trannerDetailRepository = trannerDetailRepository;
        }
        public async Task<List<TrainnerDetail>> GetAllTrannerDetails() => await _trannerDetailRepository.GetAll();
        public async Task<TrainnerDetail> GetTrannerDetailById(string id) => await _trannerDetailRepository.GetById(id);
        public async Task CreateTrannerDetail(TrainnerDetail trannerDetail) => await _trannerDetailRepository.Create(trannerDetail);
        public async Task UpdateTrannerDetail(TrainnerDetail trannerDetail) => await _trannerDetailRepository.Update(trannerDetail);
        public async Task DeleteTrannerDetail(TrainnerDetail trannerDetail) => await _trannerDetailRepository.Delete(trannerDetail);
        public async Task SoftDeleteTrannerDetail(string id) => await _trannerDetailRepository.SoftDelete(id);
    }
}
