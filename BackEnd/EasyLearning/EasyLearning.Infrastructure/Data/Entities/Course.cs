using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public enum CourseType
    {
        Online = 5,
        Offline = 10,
    }
    public class Course : GenericEntity
    {
        [Column("Courses_Name")]
        public string? CoursesName { get; set; }

        [Column("Courses_Description")]
        public string? CoursesDescription { get; set; }

        [Column("Courses_Price" , TypeName = "decimal(10,3)")]
        public decimal CoursesPrice { get; set; }

        [Column("Courses_Requirements")]
        public string? Requirements { get; set; }

        [Column("Course_Type")]
        public CourseType CourseType { get; set; }

        [Column("Courses_Content")]
        public string? CoureseContent {  get; set; }

        [Column("Courses_ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("Courses_Instructor")]
        public string? Instructor { get; set; }

        [Column("Courses_StartDate")]
        public DateTime StartDate { get; set; }

        [Column("Courses_EndDate")]
       
        public DateTime EndDate { get; set; }

        [Column("Courses_RegistrationDeadline")]
        public DateTime RegistrationDeadline { get; set; }

        [Column("Courses_MaxAttendees")]
        public int MaxAttdendees { get; set; }
        

        public ICollection<CourseDetail>? CoursesDetails {  get; set; } 
        public ICollection<TrainerDetail>? TrainerDetails { get; set; }
        public ICollection<TrainingPart>? TrainingParts { get; set; }
        public ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<Feedback>? FeedBacks { get; set; }
        public ICollection<AddOn>? AddOns { get; set; }  
        public ICollection<UserNote>? UserNotes { get; set; }
    }
}
