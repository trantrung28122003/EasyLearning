using EasyLearing.Models;
using EasyLearning.Infrastructure.Data.Repostiory;

namespace EasyLearning.Application.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<Course>> GetCourses() 
        {
            return await _courseRepository.GetAll();
        }
    }
}
