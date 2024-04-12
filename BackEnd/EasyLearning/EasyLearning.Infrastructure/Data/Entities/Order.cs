using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EasyLearning.Infrastructure.Data.Abstraction;

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
        public User? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
