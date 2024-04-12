using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class TrannerDetailService
    {
        private readonly TrannerDetailRepository _trannerDetailRepository;
        public TrannerDetailService(TrannerDetailRepository trannerDetailRepository)
        {
            _trannerDetailRepository = trannerDetailRepository;
        }

        public async Task<List<TrannerDetail>> GetTrannerDetail()
        {
            return await _trannerDetailRepository.GetAll();
        }

        public async Task<List<TrannerDetail>> GetTrannerDetailById(string id)
        {
            return await _trannerDetailRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateTrannerDetail(TrannerDetail trannerDetail)
        {
            await _trannerDetailRepository.Create(trannerDetail);
        }

        public async Task UpdateTrannerDetail(TrannerDetail trannerDetail)
        {
            await _trannerDetailRepository.Update(trannerDetail);
        }

        public async Task DeleteTrannerDetail(TrannerDetail trannerDetail)
        {
            await _trannerDetailRepository.Delete(trannerDetail);
        }

        public async Task SoftDeleteTrannerDetail(string id)
        {
            await _trannerDetailRepository.SoftDelete(id);
        }
    }
}
