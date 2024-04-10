using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class ShoppingCart
    {
        [Key]
        [Column("Shopping_Cart_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShoppingCartId { get; set; }
        public decimal? TotalPrice { get; set; }    
        public DateTime CreationDate { get; set; }
        public string PaymentMethod { get; set; } 

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
