using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class TranningPartService
    {
        private readonly TranningPartRepository _tranningPartRepository;
        public TranningPartService(TranningPartRepository tranningPartRepository)
        {
            _tranningPartRepository = tranningPartRepository;
        }

        public async Task<List<TranningPart>> GetTranningPart()
        {
            return await _tranningPartRepository.GetAll();
        }

        public async Task<List<TranningPart>> GetTranningPartById(string id)
        {
            return await _tranningPartRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateTranningPart(TranningPart tranningPart)
        {
            await _tranningPartRepository.Create(tranningPart);
        }

        public async Task UpdateTranningPart(TranningPart tranningPart)
        {
            await _tranningPartRepository.Update(tranningPart);
        }

        public async Task DeleteTranningPart(TranningPart tranningPart)
        {
            await _tranningPartRepository.Delete(tranningPart);
        }

        public async Task SoftDeleteTranningPart(string id)
        {
            await _tranningPartRepository.SoftDelete(id);
        }
    }
}
