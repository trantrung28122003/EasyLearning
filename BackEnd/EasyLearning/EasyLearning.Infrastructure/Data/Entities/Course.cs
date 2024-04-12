using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class Course : GenericEntity
    {
        [Column("Courses_Name")]
        public string? CoursesName { get; set; }

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
        public DateTime StartDate { get; set; }

        [Column("Courses_StartEnd")]
       
        public DateTime StartEnd { get; set; }

        [Column("Courese_RegistrationDeadline")]
        public DateTime RegistrationDeadline { get; set; }

        [Column("Courses_MaxAttendees")]
        public int MaxAttdendees { get; set; }
        

        public ICollection<CourseDetail>? CoursesDetails {  get; set; } 
        public ICollection<TrannerDetail>? TrannerDetails { get; set; }
        public ICollection<TranningPart>? TranningParts { get; set; }
        public ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<Feedback>? FeedBacks { get; set; }
        public ICollection<AddOn>? AddOns { get; set; }  
    }
}
