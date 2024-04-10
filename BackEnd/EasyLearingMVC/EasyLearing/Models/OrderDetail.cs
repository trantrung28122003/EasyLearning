using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class OrderDetail
    {
        [Key]
        [Required]
        [Column("Order_Detail_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderDetailId {  get; set; }

        [Column("Order_Id")]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        [Column("Courses_Id")]
        public Guid CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Courses Courses { get; set; }
    }
}
