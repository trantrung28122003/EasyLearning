using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class ShoppingCartItem
    {
        [Key]
        [Column("Shopping_Cart_Item_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShoppingCartItemId {  get; set; }

        [Column("Shopping_Cart_Item_Shopping_Cart_Id")]
        public Guid ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }

        [Column("Shopping_Cart_Item_Courese_Id")] 
        public Guid CoursesId { get; set; }
        [ForeignKey("CoursesId")]
        public Course Courses { get; set; }
    }
}
