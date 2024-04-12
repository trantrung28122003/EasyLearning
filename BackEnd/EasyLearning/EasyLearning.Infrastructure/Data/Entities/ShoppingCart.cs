using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class ShoppingCart : GenericEntity
    {
        [Column("Shopping_Cart_TotalPrice")]
        public decimal? TotalPrice { get; set; }

        [Column("Shopping_Cart_PaymentMethod")]
        public string? PaymentMethod { get; set; }

        [Column("Shopping_Cart_User_Id")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<ShoppingCartItem>? ShoppingCartItem { get; set; }
    }
}
