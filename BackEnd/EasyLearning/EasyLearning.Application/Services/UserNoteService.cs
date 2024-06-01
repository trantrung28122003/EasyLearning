using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public interface IUserNoteService
    {
        Task<List<UserNote>> GetAllUserNote();
        Task<UserNote> GetUserNoteById(string userNoteId);
        Task<List<UserNote>> GetUserNoteByCourseIdAndUserId(string courseId, string userId);
        Task CreateUserNote(UserNote userNote);
        Task UpdateUserNote(UserNote userNote);
        Task DeleteUserNote(UserNote userNote);
        Task SoftDeleteUserNote(string userNoteId);
    }

    public class UserNoteService : IUserNoteService
    {
        private readonly UserNoteRepository _userNoteRepository;
        public UserNoteService(UserNoteRepository userNoteRepository)
        {
            _userNoteRepository = userNoteRepository;
        }

        public async Task<List<UserNote>> GetAllUserNote() => await _userNoteRepository.GetAll();
        public async Task<UserNote> GetUserNoteById(string userNoteId) => await _userNoteRepository.GetById(userNoteId);
        public async Task<List<UserNote>> GetUserNoteByCourseIdAndUserId(string courseId, string userId) => await _userNoteRepository.GetNotesByCourseIdAndUserId(courseId, userId);
        public async Task CreateUserNote(UserNote userNote) => await _userNoteRepository.Create(userNote);
        public async Task UpdateUserNote(UserNote userNote) => await _userNoteRepository.Update(userNote);
        public async Task DeleteUserNote(UserNote userNote) => await _userNoteRepository.Delete(userNote);
        public async Task SoftDeleteUserNote(string id) => await _userNoteRepository.SoftDelete(id);
    }
}
