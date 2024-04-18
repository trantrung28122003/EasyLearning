using EasyLearing.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserImageUrl { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

        public string? TrainnerDetailId { get; set; }
        [ForeignKey("TrainnerDetailId")]
        public TrainerDetail? TrainnerDetail { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
