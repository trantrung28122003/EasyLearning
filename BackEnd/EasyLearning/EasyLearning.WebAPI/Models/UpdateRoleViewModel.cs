using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace EasyLearning.WebAPI.Models
{
    public class UpdateRoleViewModel
    {
        [Required]
        public ApplicationUser? user { get; set; }
        [Required]
        public ApplicationRole? role { get; set; }    
    }
}
