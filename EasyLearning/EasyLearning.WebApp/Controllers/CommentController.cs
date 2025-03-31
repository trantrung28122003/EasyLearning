using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EasyLearning.WebApp.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;
        private readonly IReplyService _replyService;
        private readonly UserRepository _userRepository;


        public CommentController(ICommentService commentService, UserRepository userRepository, IReplyService replyService)
        {
            _commentService = commentService;
            _userRepository = userRepository;
            _replyService = replyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserName(string userId)
        {
         
            var listUser = await _userRepository.GetUsersAsync();
            var userNameByComment = listUser.FirstOrDefault(u => u.Id == userId)?.FullName ?? "";
            var curenntUserId = _userRepository.getCurrrentUser();
            if (listUser == null)
            {
                return NotFound();
            }
            return Json(new { userName = userNameByComment, userId = curenntUserId }); 
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(string content, string trainingPartId)
        {
            if (ModelState.IsValid)
            {
                var listUser = await _userRepository.GetUsersAsync();
                var currentUserId = _userRepository.getCurrrentUser();
                var currentUser = listUser.FirstOrDefault(u => u.Id == currentUserId);
                var comment = new Comment
                {
                    TrainingPartId = trainingPartId,
                    ContentComment = content,
                    UserID = currentUserId, 
                    DateCreate = DateTime.Now,
                    DateChange = DateTime.Now,
                    ChangedBy = currentUserId,
                    IsDeleted = false,

                };
                await _commentService.CreateComment(comment);
                return Json(new { success = true, commentId = comment.Id, user = currentUser, content = comment.ContentComment });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(string content, string commentId)
        {
            var listUser = await _userRepository.GetUsersAsync();
            var currentUserId = _userRepository.getCurrrentUser();
            var currentUser = listUser.FirstOrDefault(u => u.Id == currentUserId);
            if (ModelState.IsValid)
            {
                var reply = new Reply
                {
                    ContentReply = content,
                    UserID = currentUserId,
                    CommentId = commentId,
                    DateCreate = DateTime.Now,
                    DateChange = DateTime.Now,
                    ChangedBy = currentUserId,
                    IsDeleted = false,

                };
                await _replyService.CreateReply(reply);

                return Json(new { success = true, replyId = reply.Id, commentId = reply.CommentId, user = currentUser, content = reply.ContentReply });
            }
            return Json(new { success = false });
        }
    }
}
