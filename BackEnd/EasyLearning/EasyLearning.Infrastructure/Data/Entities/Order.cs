using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class Order : GenericEntity
    {
        [Column("Order_TotalPrice")]
        public decimal OrderTotalPrice { get ; set; }   

        [Column("Order_PaymentMethod")]
        public string? OrderPaymentMethod {  get; set; }

        [Column("Order_Notes")]
        public string? OrderNotes { get; set; }

        [Column("Order_User")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
