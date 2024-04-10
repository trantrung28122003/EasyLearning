using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public enum EnventType
    {
        Online = 5,
        Offline = 10,
    }
    public class Event : GenericEntity
    {
        [Column("Event_Name")]
        public string EventName { get; set; }

        [Required]
        [Column("Event_Type")]
        public EnventType EventType { get; set; }

        [Required]
        [Column("Event_StartDateTime")]
        public DateTime EventStartDateTime { get; set; }

        [Required]
        [Column("Event_EndDateTime")]
        public DateTime EventEndDateTime { get; set; }

        [Required]
        [Column("Event_Location")]
        public string Location { get; set; }

        public ICollection<TranningPart> TranningParts { get; set; }
    }
}
