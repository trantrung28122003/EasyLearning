using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyLearning.WebApp.Models
{
    public class CategoryViewModel
    {
        public List<string>? SelectedCategories { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
