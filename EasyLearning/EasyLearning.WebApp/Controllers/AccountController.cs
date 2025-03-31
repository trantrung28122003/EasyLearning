using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Repostiory;
using EasyLearning.WebApp.Areas.admin.Models;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace EasyLearning.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;

        private readonly UserRepository _userRepository;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, 
            UserRepository userRepository, IShoppingCartService shoppingCartService,
            IFileService fileService, IShoppingCartItemService shoppingCartItemService, IEmailService emailService)
        {

            this._userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this._userRepository = userRepository;
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
            _fileService = fileService;
            _emailService = emailService;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            UserRegistrationViewModel model = new UserRegistrationViewModel();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationViewModel request)
        {
            if (!request.isConfirmPolicy)
            {
                return View(request);
            }
            var userImageUrl = "https://easylearning.blob.core.windows.net/images-videos/userDefault.jpg81716900-b5dd-468a-97eb-ca2678f03288";
            if (request.Avatar != null)
            {
                 userImageUrl = await _fileService.SaveFile(request.Avatar);
            }
            if (ModelState.IsValid)
            {
                
                var userCheck = await _userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new ApplicationUser
                    {
                        FullName = request.Name,
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        Address = request.Address,
                        BirthDate = request.BirthDate,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserImageUrl = userImageUrl,
                    };
                    var result = await _userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "USER");
                        var shoppingCart = new ShoppingCart()
                        {
                            UserId = user.Id,
                            DateChange = DateTime.Now,
                            DateCreate = DateTime.Now,
                            IsDeleted = false,
                        };
                        await _shoppingCartService.CreateShoppingCart(shoppingCart);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email đã tồn tại.");
                    return View(request);
                }
            }
            return View(request);
        }

        [HttpGet,AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginViewModel model = new UserLoginViewModel();
            return View(model);
        }

        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    _userRepository.setUser(user.Id);
                    return RedirectToAction("Index" , "Home");
                }
                else if (result.IsLockedOut)
                {
                    var lockoutEnd = await _userManager.GetLockoutEndDateAsync(user);
                    return View("AccountLocked", lockoutEnd);
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            _userRepository.setUser(string.Empty);
            return RedirectToAction("index","Home");
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }


        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            //string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            
            if (result.Succeeded)
            {   
                var user = await _userManager.FindByEmailAsync(info.Principal.FindFirst(ClaimTypes.Email).Value);
                _userRepository.setUser(user.Id);
            return RedirectToAction("Index", "Home");
                }
            else
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
                };

                IdentityResult identResult = await _userManager.CreateAsync(user);

                if (identResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "USER");
                    var shoppingCart = new ShoppingCart()
                    {
                        UserId = user.Id,
                        DateChange = DateTime.Now,
                        DateCreate = DateTime.Now,
                        IsDeleted = false,
                    };
                    await _shoppingCartService.CreateShoppingCart(shoppingCart);
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                       
                        await signInManager.SignInAsync(user, false);
                        _userRepository.setUser(user.Id);
                        RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> UpdateAccount()
        {
            var userId = _userRepository.getCurrrentUser();
            var user = await _userManager.FindByIdAsync(userId);
            var userProfileViewModel = new UserProfileViewModel
            {
                Avatar = user.UserImageUrl,
                Username = user.UserName,
                FullName = user.FullName,
                //Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,

            };
            return View(userProfileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccount(UserProfileViewModel userProfileViewModel, string changePasswordButton)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (changePasswordButton != null)
            {
                if (userProfileViewModel.CurrentPassword != null && userProfileViewModel.CurrentPassword != null)
                {
                    if (userProfileViewModel.NewPassword != userProfileViewModel.ConfirmPassword)
                    {
                        ModelState.AddModelError(string.Empty, "Xác nhận mật khẩu mới không khớp.");
                        return View(userProfileViewModel);
                    }
                    var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, userProfileViewModel.CurrentPassword);
                    if (!isCurrentPasswordValid)
                    {
                        ModelState.AddModelError(string.Empty, "Mật khẩu hiện tại không chính xác.");
                        return View(userProfileViewModel);
                    }
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, userProfileViewModel.CurrentPassword, userProfileViewModel.NewPassword);
                    if (!changePasswordResult.Succeeded)
                    {
                        foreach (var error in changePasswordResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(userProfileViewModel);
                    }
                    ModelState.Remove("CurrentPassword");
                    ModelState.Remove("NewPassword");
                    ModelState.Remove("ConfirmPassword");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Vui lòng nhập đủ thông tin mật khẩu.");
                    return View(userProfileViewModel);
                }
            }
            else
            {

                user.FullName = userProfileViewModel.FullName;
                //user.Address = userProfileViewModel.Address;
                user.Email = userProfileViewModel.Email;
                user.PhoneNumber = userProfileViewModel.PhoneNumber;
                //user.BirthDate = model.BirthDate;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(userProfileViewModel);
                }
            }
            return View(userProfileViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> SendVerificationCode(string email, string verificationCode)
        {
            try
            {
                string subject = verificationCode + " lã mã xác nhận yêu cầu đặt lại mật khẩu tài khoản của bạn";
                await _emailService.SendVerificationCodeAsync(email, subject, verificationCode);

                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            
            if (resetPasswordViewModel.HiddenSendVerificationCode != resetPasswordViewModel.VerificationCode)
            {
                ModelState.AddModelError("verificationCode", "Mã xác thực không chính xác. Vui lòng kiểm tra lại.");
                return View("ForgetPassword", new UserLoginViewModel { Email = resetPasswordViewModel.Email}); 
            }
            else
            {

                return RedirectToAction("ResetPassword", new { email = resetPasswordViewModel.Email });
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string email)
        {
            var resetPasswordViewModel = new ResetPasswordViewModel
            {
                Email = email
            };
            return View(resetPasswordViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }
            var userByEmail = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (userByEmail != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(userByEmail);
                var resetPasswordResult = await _userManager.ResetPasswordAsync(userByEmail, token, resetPasswordViewModel.NewPassword);
                if (resetPasswordResult.Succeeded)
                {
                    return RedirectToAction("Login");
                }

            }
            return View(resetPasswordViewModel);
        }
    }
}
