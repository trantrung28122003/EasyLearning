
namespace EasyLearning.WebApp.Models
{
    public class EventViewModel
    {
            public string? EventName { get; set; }
            public int EventType { get; set; }
            public string? Location { get; set; }
            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public DateTime? DateCreate { get; set; }
            public DateTime? DateChange { get; set; }
            public string? ChangedBy { get; set; }
            public bool IsDeleted { get; set; }
            public string? TrainingPartId { get; set; }
            public TrainingPart? TrainingPart { get; set; }

            public string? CourseId { get; set; }
    }
}

