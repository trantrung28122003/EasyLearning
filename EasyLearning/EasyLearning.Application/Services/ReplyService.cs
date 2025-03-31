using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IReplyService
    {
        Task<List<Reply>> GetAllReply();
        Task<List<Reply>> GetReplyByCommentId(string commentId);
        Task CreateReply(Reply reply);
        Task UpdateReply(Reply reply);
        Task DeleteReply(Reply reply);
        Task SoftDeleteReply(string id);
    }
    public class ReplyService : IReplyService
    {
        private readonly ReplyRepository _replyRepository;

        public ReplyService(ReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public async Task<List<Reply>> GetAllReply() => await _replyRepository.GetAll();
        public async Task<List<Reply>> GetReplyByCommentId(string commentId) => await _replyRepository.GetByCondition(x => x.CommentId == commentId);
        public async Task CreateReply(Reply reply) => await _replyRepository.Create(reply);
        public async Task UpdateReply(Reply reply) => await _replyRepository.Update(reply);
        public async Task DeleteReply(Reply reply) => await _replyRepository.Delete(reply);
        public async Task SoftDeleteReply(string id) => await _replyRepository.SoftDelete(id);
    }
}
