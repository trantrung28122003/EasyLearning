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
        public TrainnerDetail? TrannerDetail { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
