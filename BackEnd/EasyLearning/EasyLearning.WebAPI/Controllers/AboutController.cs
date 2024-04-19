using EasyLearning.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebAPI.Controllers
{
    public class AboutController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
     

        public AboutController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAbout()
        {
            List<ApplicationUser> usersAdmin = (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync("admin");
            return View(usersAdmin);
        }

    }
}
