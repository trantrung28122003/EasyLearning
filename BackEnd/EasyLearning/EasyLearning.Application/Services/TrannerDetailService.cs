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
        Task<List<TrannerDetail>> GetAllTrannerDetails();
        Task<TrannerDetail> GetTrannerDetailById(string id);
        Task CreateTrannerDetail(TrannerDetail trannerDetail);
        Task UpdateTrannerDetail(TrannerDetail trannerDetail);
        Task DeleteTrannerDetail(TrannerDetail trannerDetail);
        Task SoftDeleteTrannerDetail(string id);
    }
    public class TrannerDetailService : ITrannerDetailService
    {
        private readonly TrannerDetailRepository _trannerDetailRepository;
        public TrannerDetailService(TrannerDetailRepository trannerDetailRepository)
        {
            _trannerDetailRepository = trannerDetailRepository;
        }
        public async Task<List<TrannerDetail>> GetAllTrannerDetails() => await _trannerDetailRepository.GetAll();
        public async Task<TrannerDetail> GetTrannerDetailById(string id) => await _trannerDetailRepository.GetById(id);
        public async Task CreateTrannerDetail(TrannerDetail trannerDetail) => await _trannerDetailRepository.Create(trannerDetail);
        public async Task UpdateTrannerDetail(TrannerDetail trannerDetail) => await _trannerDetailRepository.Update(trannerDetail);
        public async Task DeleteTrannerDetail(TrannerDetail trannerDetail) => await _trannerDetailRepository.Delete(trannerDetail);
        public async Task SoftDeleteTrannerDetail(string id) => await _trannerDetailRepository.SoftDelete(id);
    }
}
