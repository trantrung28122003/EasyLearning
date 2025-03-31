using AutoMapper;
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.InteropServices;

namespace EasyLearning.WebApp.Controllers
{
    public class CustomerCoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly ICourseDetailService _courseDetailService;
        private readonly ICourseEventService _courseEventService;
        private readonly ITrainingPartService _trainingPartService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IFileService _fileService;
        private readonly UserRepository _userRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly EasyLearningDbContext _easyLearningDbContext;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IExerciseQuestionService _exerciseQuestionService;
        private readonly IAnswerService _answerService;
        private readonly ICommentService _commentService;
        private readonly IReplyService _replyService;
        private readonly IUserNoteService _userNoteService;

        private readonly IUserTrainingProgressService _userTrainingProgressService;

        public CustomerCoursesController(ICourseService courseService, ICategoryService categoryService,
        ICourseDetailService courseDetailService, IOrderService orderService, IOrderDetailService orderDetailService,
        ICourseEventService courseEventService, ITrainingPartService trainingPartService,
        IMapper mapper, IFileService fileService, UserRepository userRepository, IFeedbackService feedbackService,
        EasyLearningDbContext easyLearningDbContext, IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService,
        IUserTrainingProgressService userTrainingProgressService, IExerciseQuestionService exerciseQuestionService, IAnswerService answerService,
        ICommentService commentService, IReplyService replyService, IUserNoteService userNoteService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _courseDetailService = courseDetailService;
            _courseEventService = courseEventService;
            _trainingPartService = trainingPartService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _fileService = fileService;
            _userRepository = userRepository;
            _feedbackService = feedbackService;
            _easyLearningDbContext = easyLearningDbContext;
            _shoppingCartItemService = shoppingCartItemService;
            _shoppingCartService = shoppingCartService;
            _userTrainingProgressService = userTrainingProgressService;
            _exerciseQuestionService = exerciseQuestionService;
            _answerService = answerService;
            _commentService = commentService;
            _replyService = replyService;
            _userNoteService = userNoteService;
        }


        public async Task<IActionResult> ListCourse(string searchString)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            List<ShoppingCartItem> listShoppingCartItem = new List<ShoppingCartItem>();

            var courses = await _courseService.GetAllCourses();
            var categories = await _categoryService.GetAllCategories();
            var coursedetails = await _courseDetailService.GetAllCourseDetail();
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            if (!string.IsNullOrEmpty(_userRepository.getCurrrentUser()))
            {

                var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
                listShoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
                var orders = await _orderService.GetOrdersByUser();

                foreach (var order in orders)
                {
                    listOrderDetail.AddRange(await _orderDetailService.GetOrderDetailByOrder(order.Id));
                }
            }
            else
            {

            }
            var customerCourseViewModel = new CustomerCourseViewModel()
            {
                Courses = courses,
                Categories = categories,
                CourseDetails = coursedetails,
                ShoppingCartItems = listShoppingCartItem,
                OrderDetails = listOrderDetail,
                IsSearchResult = !string.IsNullOrEmpty(searchString),
                Feedbacks = feedbacks,
            };
            if (!string.IsNullOrEmpty(searchString))
            {

                customerCourseViewModel.Courses = courses.Where(p => p.CoursesName.ToLower().Contains(searchString.ToLower())).ToList();
            }
            else
            {
                customerCourseViewModel.Courses = courses;

            }

            return View(customerCourseViewModel);
        }

        public async Task<IActionResult> ListCourseByCategory(string categoryId)
        {
            var courses = await _courseService.GetAllCourses();
            var coursedetail = await _courseDetailService.GetAllCourseDetail();
            var category = await _categoryService.GetCategoryById(categoryId);
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            var coursesByCategory = new CustomerCourseViewModel()
            {
                Courses = courses,
                CourseDetails = coursedetail,
                Category = category,
                Feedbacks = feedbacks,
            };
            return View(coursesByCategory);
        }
        public async Task<IActionResult> DetailCourse(string courseId)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            List<TrainingPart> listTrainingPart = new List<TrainingPart>();
            List<CourseEvent> listCourseEvent = new List<CourseEvent>();
            var shoppingCart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var shoppingCartItem = await _shoppingCartItemService.GetShoppingCartItemByShopingCart(shoppingCart.Id);
            var course = await _courseService.GetCourseById(courseId);
            listTrainingPart = await _trainingPartService.GetTrainingPartByCourse(courseId);
            listCourseEvent = await _courseEventService.GetEventByCourse(courseId);
            var getFeedbackbyCourse = await _feedbackService.GetFeedbacksByCourseId(courseId);
            var getUsers = await _userRepository.GetUsersAsync();
            var orders = await _orderService.GetOrdersByUser();
            var currentUserId = _userRepository.getCurrrentUser();
            bool hasBoughtCourse = await _orderDetailService.CheckIfUserHasBoughtCourse(currentUserId, courseId);

            listTrainingPart = listTrainingPart.OrderBy(x => x.StartTime).ToList();
            listCourseEvent = listCourseEvent.OrderBy(x =>x.DateStart).ToList();
            foreach (var itemFeedback in getFeedbackbyCourse)
            {
                if (currentUserId == itemFeedback.FeedbackUserId)
                {
                    hasBoughtCourse = false;
                    break;
                }
            }
            foreach (var order in orders)
            {
                listOrderDetail = await _orderDetailService.GetOrderDetailByOrder(order.Id);
            }


            var customerCourseViewModel = new CustomerCourseViewModel()
            {
                Course = course,
                ShoppingCartItems = shoppingCartItem,
                TrainingParts = listTrainingPart,
                CourseEvents = listCourseEvent,
                Feedbacks = getFeedbackbyCourse,
                Users = getUsers,
                OrderDetails = listOrderDetail,
                HasBoughtCourse = hasBoughtCourse,
                currentUserId = currentUserId,
            };
            ViewBag.CourseId = courseId;
            return View(customerCourseViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddToFeedback(string courseId, int rating, string content)
        {
            var userId = _userRepository.getCurrrentUser();
            var feeedBack = new Feedback()
            {
                FeedbackUserId = userId,
                CoursesId = courseId,
                FeedbackRating = rating,
                FeedbackContent = content,
                DateCreate = DateTime.Now,
                DateChange = DateTime.Now,
                ChangedBy = userId,
                IsDeleted = false,
            };
            await _feedbackService.CreateFeedback(feeedBack);
            return RedirectToAction("DetailCourse", "CustomerCourses", new { courseId = courseId });

        }

        public async Task<IActionResult> EventSchedule()
        {
            List<Course> courses = new List<Course>();
            List<Course> coursesByOffline = new List<Course>();
            List<CourseEvent> listCourseEvent = new List<CourseEvent>();
            List<TrainingPart> listTrainingPart = new List<TrainingPart>();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var currentUserId = _userRepository.getCurrrentUser();
            var orders = await _orderService.GetAllOrders();
            var ordersByUser = await _orderService.GetOrdersByUser();
            foreach (var order in ordersByUser)
            {
                listOrderDetail.AddRange(await _orderDetailService.GetOrderDetailByOrder(order.Id));
            }
            foreach (var itemOrderDetail in listOrderDetail)
            {
                var trainingParts = await _trainingPartService.GetTrainingPartByCourse(itemOrderDetail.CoursesId);
                var courseEvents = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);
                listCourseEvent.AddRange(courseEvents.ToList());
                listTrainingPart.AddRange(trainingParts.ToList());
                courses.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
            }

            foreach(var itemCourse in courses)
            {
                if(itemCourse.CourseType == CourseType.Offline)
                {
                    coursesByOffline.Add(itemCourse);
                }
                
            }    
            listTrainingPart = listTrainingPart.OrderBy(x => x.StartTime).ToList();
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                currentUserId = currentUserId,
                Courses = coursesByOffline,
                CourseEvents = listCourseEvent,
                TrainingParts = listTrainingPart,
                Orders = orders,
            };
            return View(customerCourseViewModel);
        }
        //[HttpGet("GetQuizData")]

        public async Task<IActionResult> OnlineEventSchedule(string courseId)
        {

            List<UserTrainingProgress> listUserTrainingProgress = new List<UserTrainingProgress>();
            List<ExerciseQuestion> exerciseQuestionsByCourse = new List<ExerciseQuestion>();
            List<Comment> listComment = new List<Comment>();
            List<Reply> listReply = new List<Reply>();

            var ListCorrectPercentage = new List<(string userTrainingPartProgressId, int correctPercentage)>();
            var course = await _courseService.GetCourseById(courseId);
            var listCourseEvent = await _courseEventService.GetEventByCourse(courseId);
            var listTrainingPart = await _trainingPartService.GetTrainingPartByCourse(courseId);
            var currentUserId = _userRepository.getCurrrentUser();
            var listUser = await _userRepository.GetUsersAsync();
            var listNote = await _userNoteService.GetUserNoteByCourseIdAndUserId(courseId, currentUserId);
            listTrainingPart = listTrainingPart.OrderBy(x => x.StartTime).ToList();
            listCourseEvent = listCourseEvent.OrderBy(x => x.DateStart).ToList();

            foreach (var itemTrainingPart in listTrainingPart)
            {
                var userTrainingPartProgress = await _userTrainingProgressService.GetUserTrainingProgressByTrainingPartIdAndUserId(itemTrainingPart.Id, currentUserId);
                var listExerciseQuestion = await _exerciseQuestionService.GetExerciseQuestionByTraningPartId(itemTrainingPart.Id);
                var listCommentByTrainingPartId = await _commentService.GetAllCommentsWithRepliesByTrainingPart(itemTrainingPart.Id);
                listUserTrainingProgress.Add(userTrainingPartProgress);
                exerciseQuestionsByCourse.AddRange(listExerciseQuestion);
                listComment.AddRange(listCommentByTrainingPartId);
            }

            foreach (var itemComment in listComment)
            {
                var listReplyByTrainingPartId = await _replyService.GetReplyByCommentId(itemComment.Id);
                listReply.AddRange(listReplyByTrainingPartId);
            }

            foreach (var itemTrainingPart in listTrainingPart)
            {
                foreach (var itemTrainingPartProgress in listUserTrainingProgress)
                {
                    if (itemTrainingPart.Id == itemTrainingPartProgress.TrainingPartId && itemTrainingPartProgress.IsCompleted && itemTrainingPart.TrainingPartType == TrainingPartType.Exercise)
                    {
                        var listQuestionByTrainingPartId = await _exerciseQuestionService.GetExerciseQuestionByTraningPartId(itemTrainingPart.Id);
                        var questionCountByTrainingPartId = listQuestionByTrainingPartId.Count;
                        var correctPercentage = (int)Math.Round(((double)itemTrainingPartProgress.CorrectAnswersCount / questionCountByTrainingPartId) * 100);
                        ListCorrectPercentage.Add((itemTrainingPartProgress.Id, correctPercentage));
                    }
                }
            }
            ViewData["ListCorrectPercentage"] = ListCorrectPercentage;

            
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                Course = course,
                currentUserId = currentUserId,
                Users = listUser,
                CourseEvents = listCourseEvent,
                TrainingParts = listTrainingPart,
                UserTrainingProgresss = listUserTrainingProgress,
                ExerciseQuestionsByCourse = exerciseQuestionsByCourse,
                Comments = listComment,
                Replies = listReply,
                Notes = listNote,
            };
            ViewBag.CourseId = courseId;
            return View(customerCourseViewModel);
        }

        public async Task<IActionResult> OnlineEventScheduleFree(string courseId)
        {
            var course = await _courseService.GetCourseById(courseId);
            var listCourseEvent = await _courseEventService.GetEventByCourse(courseId);
            var listTrainingPart = await _trainingPartService.GetTrainingPartByCourse(courseId);
            listTrainingPart = listTrainingPart.OrderBy(x => x.StartTime).ToList();
            listCourseEvent = listCourseEvent.OrderBy(x => x.DateStart).ToList();
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                Course = course,
                CourseEvents = listCourseEvent,
                TrainingParts = listTrainingPart,
 
            };
            ViewBag.CourseId = courseId;
            return View(customerCourseViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizData(string trainingPartId)
        {
            var listQuestion = await _exerciseQuestionService.GetAllQuestionsAndAnswer(trainingPartId);

            var quizData = listQuestion.Select(x => new
            {
                question = x.Question,
                options = x.Answers.Select(p => p.Text).ToList(),
                correct = x.Answers.FirstOrDefault(a => a.IsCorrect == true)?.Text
            });
            return Ok(quizData);
        }

        [HttpPost]
        public async Task<IActionResult> TrackVideoEvent(string videoName, string percentageWatched, string trainingPartId, bool trainingPartIsComplete)
        {
            try
            {
                double percentage = double.Parse(percentageWatched);
                if (percentage >= 90)
                {
                    var userTrainingPartProgress = await _userTrainingProgressService.GetUserTrainingProgressByTrainingPartIdAndUserId(trainingPartId, _userRepository.getCurrrentUser());
                    if (userTrainingPartProgress != null)
                    {
                        userTrainingPartProgress.IsCompleted = true;
                        await _userTrainingProgressService.UpdateUserTrainingProgress(userTrainingPartProgress);

                    }
                    return RedirectToAction("Index", "Home");
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitQuizResults(string trainingPartId, string[] correctQuestionIds, bool isCompleted)
        {
            try
            {
                var trainingPart = await _trainingPartService.GetTrainingPartById(trainingPartId);
                var userTrainingPartProgress = await _userTrainingProgressService.GetUserTrainingProgressByTrainingPartIdAndUserId(trainingPartId, _userRepository.getCurrrentUser());
                if (!isCompleted)
                {
                    if (userTrainingPartProgress != null)
                    {
                        userTrainingPartProgress.IsCompleted = true;
                        userTrainingPartProgress.DateChange = DateTime.Now;
                        userTrainingPartProgress.CorrectAnswersCount = correctQuestionIds.Length;
                        await _userTrainingProgressService.UpdateUserTrainingProgress(userTrainingPartProgress);
                    }
                }
                else
                {
                    if (userTrainingPartProgress != null)
                    {
                        userTrainingPartProgress.DateChange = DateTime.Now;
                        await _userTrainingProgressService.UpdateUserTrainingProgress(userTrainingPartProgress);
                    }
                }

                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<IActionResult> ListCourseOnlineByUser()
        {
            List<Course> courses = new List<Course>();
            List<Course> coursesByOnline = new List<Course>();
            List<CourseEvent> listCourseEvent = new List<CourseEvent>();
            List<TrainingPart> listTrainingPart = new List<TrainingPart>();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            var currentUserId = _userRepository.getCurrrentUser();
            var orders = await _orderService.GetAllOrders();
            var ordersByUser = await _orderService.GetOrdersByUser();
            var listUserTrainingProgress = await _userTrainingProgressService.GetUserTrainingProgressByUserId(currentUserId);
            foreach (var order in ordersByUser)
            {
                listOrderDetail.AddRange(await _orderDetailService.GetOrderDetailByOrder(order.Id));
            }
            foreach (var itemOrderDetail in listOrderDetail)
            {
                var trainingParts = await _trainingPartService.GetTrainingPartByCourse(itemOrderDetail.CoursesId);
                var courseEvents = await _courseEventService.GetEventByCourse(itemOrderDetail.CoursesId);
                listCourseEvent.AddRange(courseEvents.ToList());
                listTrainingPart.AddRange(trainingParts.ToList());
                courses.AddRange(await _courseService.GetCourseByOrderDetail(itemOrderDetail.Id));
            }
            listTrainingPart = listTrainingPart.OrderBy(x => x.StartTime).ToList();

            foreach (var itemCourse in courses)
            {
                if (itemCourse.CourseType == CourseType.Online)
                {
                    coursesByOnline.Add(itemCourse);
                }

            }
            var customerCourseViewModel = new CustomerCourseViewModel
            {
                currentUserId = currentUserId,
                Courses = coursesByOnline,
                CourseEvents = listCourseEvent,
                TrainingParts = listTrainingPart,
                Orders = orders,
                UserTrainingProgresss = listUserTrainingProgress,
            };
            return View(customerCourseViewModel);
        }
    }
}
