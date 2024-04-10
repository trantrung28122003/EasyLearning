using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class Category
    {
        [Key]
        [Column("Category_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }

        [Column("Category_Name")]
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("Category_Sort_Order")]
        public int? SortOrder { get; set; }

        public ICollection<CoursesDetail> CoursesDetails { get; set;}
    }
}
