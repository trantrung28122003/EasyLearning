using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(string id);
        Task CreateCourse(Course courses);
        Task UpdateCourse(Course course);
        Task DeleteCourse(Course course);
        Task SoftDeleteCourse(string id);
    }
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<Course>> GetAllCourses() => await _courseRepository.GetAll();
        public async Task<Course> GetCourseById(string id) => await _courseRepository.GetById(id);
        public async Task CreateCourse(Course courses) => await _courseRepository.Create(courses);
        public async Task UpdateCourse(Course course) => await _courseRepository.Update(course);
        public async Task DeleteCourse(Course course) => await _courseRepository.Delete(course);
        public async Task SoftDeleteCourse(string id) => await _courseRepository.SoftDelete(id);
    }
}
