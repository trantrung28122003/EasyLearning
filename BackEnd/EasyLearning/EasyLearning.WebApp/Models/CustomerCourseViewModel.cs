using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Models
{
    public class CustomerCourseViewModel
    {
        public List<Course>? Courses { get; set; }
        public List<CourseEvent>? CourseEvents { get; set; }
        public List<TranningPart>? TranningParts { get; set; }
    }

}
