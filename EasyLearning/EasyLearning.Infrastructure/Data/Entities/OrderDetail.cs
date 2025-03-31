using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class OrderDetail : GenericEntity
    {
        [Column("Order_Id")]
        public string? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Column("Courses_Id")]
        public string? CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course? Courses { get; set; }
    }
}
