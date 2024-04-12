using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearing.Infrastructure.Data.Entities
{
    public class User : GenericEntity
    {
        [Column("User_Name")]
        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }

        [Column("User_Email")]
        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Column("User_Phone")]
        [Required]
        [StringLength(11)]
        public string? UserPhone { get; set; }

        [Column("User_Password")]
        [Required]
        [StringLength(100)]
        public string? UserPassword { get; set; }

        [Column("User_Fullname")]
        [Required]
        public string? UserFullName { get; set; }

        [Column("User_Address")]
        public string? UserAddress { get; set; }

        [Column("User_Gender")]
        [Required]
        public bool UserGender { get; set; }

        [Column("User_UserAvatar")]
        public string? UserAvatar { get; set; }

        [Column("User_UserRole")]
        public string? UserRole { get; set; }
        [ForeignKey("UserRole")]
        public UserRole? UserRoles { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }
        public ICollection<TrannerDetail>? TrannerDetails { get; set; }
        public ICollection<Order>? Orders {  get; set; }      
    }
}
