using EasyLearing.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ShoppingCart? ShoppingCart { get; set; }

        public string? TrannerDetailId { get; set; }
        [ForeignKey("TrannerDetailId")]
        public TrainerDetail? TrannerDetail { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public string? Image { get; set; }

        [Column("Courese_ImageUrl")]
        public string? ImageUrl { get; set; }
    }
}
