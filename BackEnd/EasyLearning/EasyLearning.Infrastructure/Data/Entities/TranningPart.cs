using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class TranningPart : GenericEntity
    {
        [Column("Tranning_Part_Name")]
        public string? TranningPartName { get; set; }

        [Column("Tranning_Part_StartTime")]
        public DateTime StartTime { get; set; }

        [Column("Tranning_Part_EndTime")]
        public DateTime EndTime { get; set; }

        [Column("Tranning_Part_Description")]
        public string? Description { get; set; }

        [Column("Tranning_Part_Event_Id")]
        public string? EventId { get; set; }
        [ForeignKey("TranningPartEventId")]
        public CourseEvent? CourseEvent { get; set; }

        [Column("Tranning_Part_Courese_Id")]
        public string? CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course? Courses { get; set; }
    }
}
