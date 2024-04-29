using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class Category : GenericEntity
    {
        [Column("Category_Name")]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        [Column("Img_link")]
        public string? ImageLink { get; set; }

        [Column("Category_Sort_Order")]
        public int? SortOrder { get; set; }

        public ICollection<CourseDetail>? CoursesDetails { get; set;}
    }
}
