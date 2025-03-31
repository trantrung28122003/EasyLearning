using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Areas.admin.Models
{

    public class CourseViewModel
    {
        public string? CourseId {  get; set; }
        public string? CoursesName { get; set; }

        public string? CoursesDescription { get; set; }

        public decimal CoursesPrice { get; set; }

        public string? Requirements { get; set; }

        public string? CoureseContent { get; set; }

        public CourseType CourseType { get; set; }

        public IFormFile? Image { get; set; }

        public string? CurrentImage { get; set; }
        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }

        public DateTime? DateChange { get; set; }
        public string? ChangedBy { set; get; }

        public DateTime RegistrationDeadline { get; set; }

        public string? Instructor { get; set; }

        public int MaxAttdendees { get; set; }


    }
}
