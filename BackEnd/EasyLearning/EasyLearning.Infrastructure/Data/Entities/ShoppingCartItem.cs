using EasyLearning.Infrastructure.Data.Abstraction;
using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class ShoppingCartItem: GenericEntity
    {
        [Column("Shopping_Cart_Item_Name")]
        public string? CartItemName { get; set; }

        [Column("Shopping_Cart_Item_Quantity")]
        public int? Quantity { get; set; }

        [Column("Shopping_Cart_Item_ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("Shopping_Cart_Item_Price")]
        public decimal? CartItemPrice { get; set; }
       
        [Column("Shopping_Cart_Id")]
        public string? ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart? ShoppingCart { get; set; }

        [Column("Courese_Id")]
        public string? CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course? Courses { get; set; }
    }
}
