using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyLearing.Models
{
    public class FeedBack
    {
        [Key]
        [Column("Feedback_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FeedbackId { get; set; }


        [Column("Feedback_User_Id")]
        [Required]
        public Guid FeedbackUserId { get; set; }

        [Column("Feeback_Content")]
        public string? FeedbackContent { get; set; }

        [Column("Feeback_Rating")]
        public int FeedbackRating { get; set; }

        [Column("Feeback_SubmissionTime")]
        public DateTime SubmissionTime { get; set; }

        [Column("Feedback_Courese_Id")]
        public Guid CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course Courses { get; set; }

    }
}
