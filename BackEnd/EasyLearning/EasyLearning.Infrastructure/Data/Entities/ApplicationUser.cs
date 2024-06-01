using EasyLearing.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? UserImageUrl { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public ICollection<TrainerDetail>? TrainerDetails { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<UserTrainingProgress>? UserTrainingProgresss { get; set; }
        public ICollection<UserNote>? UserNotes { get; set; }
    }
}
