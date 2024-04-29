using EasyLearing.Infrastructure.Data.Entities;

namespace EasyLearning.WebAPI.Models
{
    public class OrderViewModel
    {
        public decimal OrderTotalPrice { get; set; }

        public string? OrderPaymentMethod { get; set; }

        public string? OrderNotes { get; set; }

        public string? UserId { get; set; }

        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
