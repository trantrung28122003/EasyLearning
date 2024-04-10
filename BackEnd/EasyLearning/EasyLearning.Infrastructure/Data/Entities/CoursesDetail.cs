using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class CoursesDetail
    {
        [Key]
        [Column("Courses_Detail_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CoursesDetailId { get; set; }


        [Column("Courese_Courses_Id")]
        public Guid CoursesCoursesId { get; set; }
        [ForeignKey("CoursesCoursesId")]
        public Course Courses { get; set; }


        [Column("Courese_Category_Id")]
        public Guid CoursesCategoryId { get; set; }
        [ForeignKey("CoursesCategoryId")]
        public Category Category { get; set; }
    }
}
