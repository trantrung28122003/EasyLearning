using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class ShoppingCart : GenericEntity
    {
        [Column("Shopping_Cart_TotalPrice", TypeName = "decimal(10,3)")]
        public decimal? TotalPrice { get; set; }

        [Column("Shopping_Cart_PaymentMethod")]
        public string? PaymentMethod { get; set; }

        [Column("Shopping_Cart_User_Id")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public ICollection<ShoppingCartItem>? ShoppingCartItem { get; set; }
    }
}
