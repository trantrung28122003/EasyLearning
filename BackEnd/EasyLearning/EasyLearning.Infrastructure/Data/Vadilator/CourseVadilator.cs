using EasyLearing.Models;
using FluentValidation;

namespace EasyLearning.Infrastructure.Data.Vadilator
{
    public class CourseVadilator : AbstractValidator<Course>
    {
        public CourseVadilator()
        {
            RuleFor(x => x.CoursesName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Thiếu tên kìa con đỉ ơi");
        }
    }
}
