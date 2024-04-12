using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class Feedback : GenericEntity
    {
        [Column("Feedback_User_Id")]
        public string? FeedbackUserId { get; set; }

        [Column("Feeback_Content")]
        public string? FeedbackContent { get; set; }

        [Column("Feeback_Rating")]
        public int FeedbackRating { get; set; }

        [Column("Feedback_Courese_Id")]
        public string? CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course? Courses { get; set; }
    }
}
