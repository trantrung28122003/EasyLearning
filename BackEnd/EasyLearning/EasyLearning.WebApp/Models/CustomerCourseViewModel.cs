using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Models
{
    public class CustomerCourseViewModel
    {
        public Course? Course { get; set; }
        public CourseEvent? CourseEvent { get; set; }
        public TranningPart? TranningPart { get; set; }
    }

}
