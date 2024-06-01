using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class UserNote : GenericEntity
    {
        [Column("NoteContent ")]
        public string? NoteContent { get; set; }
        [Column("Time")]
        public string? Time { get; set; }

        [Column("TrainingPartId")]
        public string? TrainingPartId { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Column("CoursesId")]
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
    }
}
