using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyLearing.Models
{
    public class Order
    {
        [Key]
        [Required]
        [Column("Order_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

        [Column("Order_Date")]
        public DateTime OrderDate { get; set; }

        [Column("Order_TotalPrice")]
        public decimal OrderTotalPrice { get ; set; }   

        [Column("Order_PaymentMethod")]
        public string OrderPaymentMethod {  get; set; }

        [Column("Order_Notes")]
        public string? OrderNotes { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
