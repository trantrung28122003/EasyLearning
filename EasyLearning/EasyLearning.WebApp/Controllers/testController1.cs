using EasyLearning.Application.Services;
using EasyLearning.Infrastructure.Data.Entities;
using EasyLearning.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyLearning.WebApp.Controllers
{
    public class testController1 : Controller
    {
        private readonly IEmailService _emailService;
        public testController1(IEmailService emailService) { 
            _emailService = emailService;
        }

        public async Task<IActionResult> sendEmail()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> sendEmail(EmailViewModel emailViewModel) 
        {
            emailViewModel.toEmail = "trantrung28122003@gmail.com";
            emailViewModel.subject = "test";
            emailViewModel.message = "test";
            emailViewModel.orderId = "test";
            //await _emailService.SendEmailAsync(emailViewModel.toEmail, emailViewModel.subject, emailViewModel.message, emailViewModel.orderId);
            return View();
        }
    }
}
