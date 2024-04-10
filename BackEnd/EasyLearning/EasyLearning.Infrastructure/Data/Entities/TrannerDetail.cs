using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EasyLearing.Models
{
    public class TrannerDetail
    {
        [Key]
        [Required]
        [Column("Tranner_Detail_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TrannerDetailId { get; set; }

        [Column("Courses_Id")]
        public Guid CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course Courses { get; set; }

        [Column("User_Id")]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
