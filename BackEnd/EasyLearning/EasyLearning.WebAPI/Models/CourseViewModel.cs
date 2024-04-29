namespace EasyLearning.WebAPI.Models
{
    public class CourseViewModel
    {
        public string? CoursesName { get; set; }

        public string? CoursesDescription { get; set; }

        public decimal CoursesPrice { get; set; }

        public string? Requirements { get; set; }

        public string? CoureseContent { get; set; }

        public IFormFile? Image { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime StartEnd { get; set; }

        public DateTime RegistrationDeadline { get; set; }

        public string? Instructor { get; set; }

        public int MaxAttdendees { get; set; }


    }
}
