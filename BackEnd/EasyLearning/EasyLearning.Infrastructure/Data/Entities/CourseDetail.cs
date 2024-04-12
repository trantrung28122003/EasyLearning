using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class CourseDetail : GenericEntity
    {
        [Column("Courses_Id")]
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? course { get; set; }

        [Column("Category_Id")]
        public string? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
