using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        private List<ApplicationUser> users { set; get; }
        private List<ApplicationRole> roles { set; get; }
        public UserController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {

            this.userManager = userManager;
            this.roleManager = roleManager;

            users = userManager.Users.ToList();
            roles = roleManager.Roles.ToList();
        }
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> users = await userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> UpdateRoleForUser(string id)
        {
            ViewBag.roles = users;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoleForUser(UpdateRoleViewModel model)
        {

            if (model.user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (!await roleManager.RoleExistsAsync(model?.role?.Name))
            {
                throw new ArgumentException("Role does not exist");
            }

            var currentRole = await userManager.GetRolesAsync(model.user);
            if (currentRole.Any())
            {
                await userManager.RemoveFromRoleAsync(model.user, currentRole.FirstOrDefault());
            }

            await userManager.AddToRoleAsync(model.user, model?.role?.Name);
            return View();
        }
    }
}
