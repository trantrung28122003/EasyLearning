using EasyLearing.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ShoppingCart? ShoppingCart { get; set; }

        public string? TrannerDetailId { get; set; }
        [ForeignKey("TrannerDetailId")]
        public TrainnerDetail? TrannerDetail { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
