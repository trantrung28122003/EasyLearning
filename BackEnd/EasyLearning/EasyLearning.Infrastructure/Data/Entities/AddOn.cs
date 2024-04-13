using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class AddOn : GenericEntity
    {
        [Column("Add_On_Name")]
        public string? AddOnName { get; set; }
        [Column("link_download")]
        public string? LinkDownload {  get; set; }
        [Column("price")]
        public decimal? Price { get; set; }
        public Guid CoursesId { get; set; }
        [ForeignKey("CoureseId")]
        public Course? Course { get; set; }

    }
}
