using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class Discount : GenericEntity
    {
        [Column("Discount_Code")]
        public string? Code { get; set; }
        [Column("Discount_Description")]
        public string? Description { get; set; }
        [Column("Discount_Percentage")]
        public decimal DiscountPercentage { get; set; }

        public ICollection<CourseDiscount>? CourseDiscounts { get; set; }
        public ICollection<OrderDiscount>? OrderDiscounts { get; set; }
    }
}
