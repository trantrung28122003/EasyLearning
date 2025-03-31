using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class CourseDiscount :GenericEntity
    {
        [Column("CourseDiscount_CourseId")]
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        [Column("CourseDiscount_DiscountId")]
        public string? DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }
    }
}
