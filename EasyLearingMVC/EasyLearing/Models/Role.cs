using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class Role
    {
        [Key]
        [Column("Role_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleId { get; set; }

        [Column("Role_Name")]
        [Required]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
