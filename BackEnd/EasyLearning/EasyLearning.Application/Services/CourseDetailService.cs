using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Application.Services
{
    public class CourseDetailService
    {
        private readonly CourseDetailRepository _courseDetailRepository; 

        public CourseDetailService (CourseDetailRepository courseDetailRepository)
        {
            _courseDetailRepository = courseDetailRepository;
        }

        public async Task<List<CourseDetail>> GetCourseDetail()
        {
            return await _courseDetailRepository.GetAll();
        }

        public async Task<List<CourseDetail>> GetcourseDetailById(string id)
        {
            return await _courseDetailRepository.GetByCondition(s => s.Id == id);
        }

        public async Task CreateCourseDetail(CourseDetail courseDetail)
        {
            await _courseDetailRepository.Create(courseDetail);
        }

        public async Task UpdateCourseDetail(CourseDetail courseDetail)
        {
            await _courseDetailRepository.Update(courseDetail);
        }

        public async Task DeleteCourseDetail(CourseDetail courseDetail)
        {
            await _courseDetailRepository.Delete(courseDetail);
        }

        public async Task SoftDeleteCourseDetail(string id)
        {
            await _courseDetailRepository.SoftDelete(id);
        }
    }
}
