using EasyLearing.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.WebApp.Models
{
    public class CourseCreateViewModel
    {
        public string? CoursesName { get; set; }

        public string? CoursesDescription { get; set; }

        public decimal CoursesPrice { get; set; }

        public string? Requirements { get; set; }

        public string? CoureseContent { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime StartEnd { get; set; }

        public DateTime RegistrationDeadline { get; set; }

        public int MaxAttdendees { get; set; }

        public Category? Category { get; set; }

    }
}
