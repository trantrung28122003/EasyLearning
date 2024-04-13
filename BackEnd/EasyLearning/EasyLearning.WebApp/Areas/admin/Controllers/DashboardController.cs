using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
