using EasyLearing.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Areas.admin.Models
{
    public class TrainingPartViewModel
    {   
        public string? TrainingPartId { get; set; }  
        public string? CoursesId { get; set; }
        public string? EventId { get; set; }
        public string? TrainingPartName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Description { get; set; }
        public TrainingPartType TrainingPartType { get; set; }
        public string? VideoUrl { get; set; }
        public IFormFile? Video { get; set; }
        public bool IsFree {  get; set; }
    }
}
