using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EasyLearing.Models
{
    public class Courses
    {
        [Key]
        [Column("Courses_Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CoursesId { get; set; }


        [Column("Courses_Name")]
        [Required]
        public string CoursesName { get; set; }


        [Column("Courses_Description")]
        public string? CoursesDescription { get; set; }


        [Column("Courses_Price")]
        public decimal CoursesPrice { get; set; }


        [Column("Courses_Requirements")]
        public string? Requirements { get; set; }


        [Column("Courses_Content")]
        public string? CoureseContent {  get; set; }

        [Column("Courese_ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("Courses_StartDate")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("Courses_StartEnd")]
        [Required]
        public DateTime StartEnd { get; set; }


        [Column("Courese_RegistrationDeadline")]
        [Required]
        public DateTime RegistrationDeadline { get; set; }

        [Column("Courses_MaxAttendees")]
        public DateTime MaxAttdendees { get; set; }
        

        public ICollection<CoursesDetail> CoursesDetails {  get; set; } 
        public ICollection<TrannerDetail> TrannerDetails { get; set; }
        public ICollection<TranningPart> TranningParts { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }

    }
}
