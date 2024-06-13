using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EasyLearning.WebApp.Views.Shared.Component
{
    public class CurrentUserViewComponent : ViewComponent
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentUserViewComponent(UserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = _userRepository.getCurrrentUser();
            bool isAdmin = await IsUserAdminAsync(currentUser);
            return View("ViewCurrentUserComponent", isAdmin);
        }

        public async Task<bool> IsUserAdminAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;
            return await _userManager.IsInRoleAsync(user, "ADMIN");
        }
    }
}
