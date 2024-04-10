using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class TranningPart
    {
        [Key]
        [Required]
        [Column("Tranning_Part_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TranningPartId { get; set; }

        [Column("Tranning_Part_Event_Id")]
        public Guid EventId { get; set; }
        [ForeignKey("TranningPartEventId")]
        public Event Event { get; set; }

        [Column("Tranning_Part_Courese_Id")]
        public Guid CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course Courses { get; set; }

        [Column("Tranning_Part_Role")]
        public Guid TranningPartRoleId { get; set; }
    }
}
