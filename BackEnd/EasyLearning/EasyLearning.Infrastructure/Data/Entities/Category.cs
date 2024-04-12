using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class Category : GenericEntity
    {
        [Column("Category_Name")]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        [Column("Category_Sort_Order")]
        public int? SortOrder { get; set; }

        public ICollection<CourseDetail>? CoursesDetails { get; set;}
    }
}
