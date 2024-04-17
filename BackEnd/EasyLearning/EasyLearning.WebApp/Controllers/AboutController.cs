using AutoMapper;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
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
