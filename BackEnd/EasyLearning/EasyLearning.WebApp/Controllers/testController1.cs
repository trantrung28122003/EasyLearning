using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class testController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
