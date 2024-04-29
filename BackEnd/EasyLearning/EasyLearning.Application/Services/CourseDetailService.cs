using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repository;
using EasyLearning.Infrastructure.Data.Repository;

namespace EasyLearning.Application.Services
{
    public interface ICourseDetailService
    {
        Task<List<CourseDetail>> GetAllCourseDetail();
        Task<CourseDetail> GetCourseDetailById(string id);
        Task CreateCourseDetail(CourseDetail courseDetail);
        Task UpdateCourseDetail(CourseDetail courseDetail);
        Task DeleteCourseDetail(CourseDetail courseDetail);
        Task SoftDeleteCourseDetail(string id);
    }
    public class CourseDetailService : ICourseDetailService
    {
        private readonly CourseDetailRepository _courseDetailRepository; 

        public CourseDetailService (CourseDetailRepository courseDetailRepository)
        {
            _courseDetailRepository = courseDetailRepository;
        }

        public async Task<List<CourseDetail>> GetAllCourseDetail() => await _courseDetailRepository.GetAll();
        public async Task<CourseDetail> GetCourseDetailById(string id) => await _courseDetailRepository.GetById(id);
        public async Task CreateCourseDetail(CourseDetail courseDetail) => await _courseDetailRepository.Create(courseDetail);
        public async Task UpdateCourseDetail(CourseDetail courseDetail) => await _courseDetailRepository.Update(courseDetail);     
        public async Task DeleteCourseDetail(CourseDetail courseDetail) => await _courseDetailRepository.Delete(courseDetail);
        public async Task SoftDeleteCourseDetail(string id) => await _courseDetailRepository.SoftDelete(id);
    }
}
