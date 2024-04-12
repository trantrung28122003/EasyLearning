using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class UserRole : GenericEntity
    {
        [Column("Role_Name")]
        [Required]
        public string? RoleName { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
