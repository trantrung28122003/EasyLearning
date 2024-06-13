
using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Areas.admin.Models;

namespace EasyLearning.WebApp.Models
{
    public class EventViewModel
    {
            public string? EventId { get; set; }
            public string? EventName { get; set; }
            public CourseEventType? EventType { get; set; }
            public string? Location { get; set; }
            public string? OnlineRoomUrl { get; set; }  
            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public DateTime? DateCreate { get; set; }
            public DateTime? DateChange { get; set; }
            public string? ChangedBy { get; set; }
            public bool? IsDeleted { get; set; }
            public string? TrainingPartId { get; set; }
            public TrainingPartViewModel? TrainingPartViewModel { get; set; }
            public List<TrainingPart>? TrainingParts { get; set; } = new List<TrainingPart>();
            public string? CourseId { get; set; }
            
    }
}

