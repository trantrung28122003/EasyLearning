using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllComment();
        Task<List<Comment>> GetCommentByTraningPartId(string traningPartId);
        Task<List<Comment>> GetAllCommentsWithRepliesByTrainingPart(string trainingPartId);
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(Comment comment);
        Task SoftDeleteComment(string id);
    }
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetAllComment() => await _commentRepository.GetAll();
        public async Task<List<Comment>> GetCommentByTraningPartId(string traningPartId) => await _commentRepository.GetByCondition(x => x.TrainingPartId == traningPartId);
        public async Task<List<Comment>> GetAllCommentsWithRepliesByTrainingPart(string traningPartId) => await _commentRepository.GetAllCommentsWithRepliesByTrainingPart(traningPartId);
        public async Task CreateComment(Comment comment) => await _commentRepository.Create(comment);
        public async Task UpdateComment(Comment comment) => await _commentRepository.Update(comment);
        public async Task DeleteComment(Comment comment) => await _commentRepository.Delete(comment);
        public async Task SoftDeleteComment(string id) => await _commentRepository.SoftDelete(id);
    }
}
