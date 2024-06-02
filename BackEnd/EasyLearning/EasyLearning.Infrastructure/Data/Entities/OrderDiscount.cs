using EasyLearing.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class OrderDiscount
    {
        [Column("CourseDiscount_OrderId")]
        public string? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Column("CourseDiscount_DiscountId")]
        public string? DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }
    }
}
