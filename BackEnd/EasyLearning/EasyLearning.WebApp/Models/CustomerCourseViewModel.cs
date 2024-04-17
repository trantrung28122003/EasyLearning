using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Models
{
    public class CustomerCourseViewModel
    {
        public Course? Course { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Category>? Categories { get; set; }
        public List<CourseDetail>? CourseDetails { get; set; }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public List<CourseEvent>? CourseEvents { get; set; }
        public List<TranningPart>? TranningParts { get; set; }
        public List<Feedback>? Feedbacks { get; set; }
        public List<ApplicationUser>? Users { get; set; }
        public List<ApplicationUser>? UsersAdmin { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }

}
