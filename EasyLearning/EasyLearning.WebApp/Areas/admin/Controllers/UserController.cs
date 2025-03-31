using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace EasyLearning.WebApp.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserRepository _userRepository;
        private List<ApplicationUser> users { set; get; }
        private List<ApplicationRole> roles { set; get; }
        public UserController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, UserRepository userRepository)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserViewModel
                {
                    UserId = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    LockoutEnd = user.LockoutEnd,
                    Roles = roles.ToList()
                });
            }
            ViewBag.CurrentUserId = _userRepository.getCurrrentUser();
            return View(userViewModels);
        }

        public async Task<IActionResult> LockUser(string email, int lockYears, DateTime endDate)
       {
            if (endDate != null)
            {
                endDate = DateTime.Now.AddYears(lockYears);
            }
            var userByEmail = await _userManager.FindByEmailAsync(email);
           
            var lockUserByEmail = await _userManager.SetLockoutEnabledAsync(userByEmail, true);
            var lockUserDateByEmail = await _userManager.SetLockoutEndDateAsync(userByEmail, endDate);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UnLockUser(string email)
        {
            var userByEmail = await _userManager.FindByEmailAsync(email);
            if (userByEmail == null)
            {
                return NotFound();
            }
            DateTime datetime = DateTime.Now - TimeSpan.FromMinutes(1);
            var lockUserDateByEmail = await _userManager.SetLockoutEndDateAsync(userByEmail, datetime);
            return RedirectToAction("Index");
         

        }

        [HttpPost]
        public async Task<IActionResult> ChangeRoleUser(string id, List<string> roles)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, userRoles);

                if (result.Succeeded)
                {
                    result = await _userManager.AddToRolesAsync(user, roles);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                }
            }

            return BadRequest();
        }
        public async Task<IActionResult> UpdateRoleForUser(string id)
        {
            ViewBag.roles = users;
            return View();
        }
        /*[HttpPost]
        public async Task<IActionResult> UpdateRoleForUser(UpdateRoleViewModel model)
        {

            if (model.user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (!await _roleManager.RoleExistsAsync(model?.role?.Name))
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
        }*/


    }
}
