using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLearning.WebApp.Models
{
    public class OrderViewModel
    {
        public decimal OrderTotalPrice { get; set; }
        public string? OrderPaymentMethod { get; set; }
        public string? OrderNotes { get; set; }
        public string? UserId { get; set; }
        public int TotalCourses { get; set; }
        public List<Course>? listCourse { get; set; }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
