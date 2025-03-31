using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public enum TrainingPartType
    {
        Lesson = 5,
        Exercise = 10,
    }
    public class TrainingPart : GenericEntity
    {
        [Column("Training_Part_Name")]
        public string? TrainingPartName { get; set; }

        [Column("Training_Part_StartTime")]
        public DateTime StartTime { get; set; }

        [Column("Training_Part_EndTime")]
        public DateTime EndTime { get; set; }

        [Column("Training_Part_Description")]
        public string? Description { get; set; }

        [Column("Training_Part_Type")]
        public TrainingPartType TrainingPartType { get; set; }

        [Column("Training_Part_ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("Training_Part_VideoUrl")]
        public string? VideoUrl { get; set; }

        [Column("Training_Part_IsFree")]
        public bool IsFree { get; set; }

        [Column("Training_Part_Event_Id")]
        public string? EventId { get; set; }

        [ForeignKey("EventId")]
        public CourseEvent? CourseEvent { get; set; }

        [Column("Training_Part_Courese_Id")]
        public string? CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course? Courses { get; set; }
        public ICollection<UserTrainingProgress>? UserTrainingProgresss { get; set; }
        public ICollection<ExerciseQuestion>? ExerciseQuestions { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
