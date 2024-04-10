using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Models
{
    public class User
    {
        [Key]
        [Column("User_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Column("User_Name")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Column("User_Email")]
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Column("User_Phone")]
        [Required]
        [StringLength(11)]
        public string UserPhone { get; set; }

        [Column("User_Password")]
        [Required]
        public string UserPassword { get; set; }

        [Column("User_Fullname")]
        [Required]
        public string UserFullName { get; set; }

        [Column("User_Address")]
        public string? UserAddress { get; set; }

        [Column("User_Gender")]
        [Required]
        public bool UserGender { get; set; }

        [Column("User_UserAvatar")]
        public string? UserAvatar { get; set; }

        [Column("User_UserRole")]
        public Guid UserRole { get; set; }
        [ForeignKey("UserRole")]
        public Role Role { get; set; }
        public ICollection<TrannerDetail> TrannerDetails { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
