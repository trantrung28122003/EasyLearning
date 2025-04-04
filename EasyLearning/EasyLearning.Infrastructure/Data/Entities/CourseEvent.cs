﻿

using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public enum CourseEventType
    {
        Online = 5,
        Offline = 10,
    }
    public class CourseEvent : GenericEntity
    {
        [Column("Course_Event_Name")]
        public string? EventName { get; set; }

        [Column("Course_Event_Type")]
        public CourseEventType EventType { get; set; }

        [Column("Course_Event_Location")]
        public string? Location { get; set; }

        [Column("Course_Event_Date_Start")]
        public DateTime DateStart { get; set; }

        [Column("Course_Event_Date_End")]
        public DateTime DateEnd { get; set; }

        public ICollection<TrainingPart>? TrainingParts { get; set; }
    }
}
