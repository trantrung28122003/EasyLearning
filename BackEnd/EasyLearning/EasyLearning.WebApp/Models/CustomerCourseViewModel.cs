using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Models
{
    public class CustomerCourseViewModel
    {
        public Course? Course { get; set; }
        public List<Course>? Courses { get; set; }
        public List<CourseEvent>? CourseEvents { get; set; }
        public List<TranningPart>? TranningParts { get; set; }
        public List<Feedback>? Feedbacks { get; set; }
        public List<ApplicationUser>? Users { get; set; }    
    }

}
