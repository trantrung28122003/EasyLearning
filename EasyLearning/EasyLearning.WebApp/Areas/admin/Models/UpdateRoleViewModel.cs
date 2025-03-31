using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace EasyLearning.WebApp.Areas.admin.Models
{
    public class UpdateRoleViewModel
    {
        [Required]
        public ApplicationUser? user { get; set; }
        [Required]
        public ApplicationRole? role { get; set; }    
    }
}
