using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.Application.Services
{
    public interface IEmailService
    {
        Task SendEmailPayMentAsync(string toEmail, string subject, string customerName, string totalAmount, string totalCourses, string authorizationCode, string orderDate, List<string> courseNameList);
        Task SendVerificationCodeAsync(string toEmail, string subject, string verificationCode);
      
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailPayMentAsync(string toEmail, string subject, string customerName, string totalAmount, string totalCourses, string authorizationCode, string orderDate, List<string> courseNameList)
        {
            try
            {
                string emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "EmailTemplates", "EmailPayment.html");
                string emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);

                StringBuilder coursesBuilder = new StringBuilder();
                foreach (var courseName in courseNameList)
                {
                    coursesBuilder.AppendLine($"<li>{courseName}</li>");
                }
                string courses = coursesBuilder.ToString();
      
                string emailBody = emailTemplate
                    .Replace("[CustomerName]", customerName)
                    .Replace("[totalAmount]", totalAmount)
                    .Replace("[totalCourses]", totalCourses)
                    .Replace("[Danh Sách Khóa Học]", courses)
                    .Replace("[orderdate]", orderDate)
                    .Replace("[uthorizationCode]", authorizationCode);

                var smtpClient = new SmtpClient(_configuration["EmailConfig:Host"], Convert.ToInt32(_configuration["EmailConfig:Port"]))
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_configuration["EmailConfig:Username"], _configuration["EmailConfig:Password"]),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailConfig:FromEmail"]),
                    Subject = subject,
                    Body = emailBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; 
            }
        }
        public async Task SendVerificationCodeAsync(string toEmail, string subject, string verificationCode)
        {
            try
            {
                string emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "EmailTemplates", "EmailVerification.html");
                string emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);

                StringBuilder coursesBuilder = new StringBuilder();
                
                string courses = coursesBuilder.ToString();

                string emailBody = emailTemplate
                    .Replace("[verificationCode]", verificationCode);
                    

                var smtpClient = new SmtpClient(_configuration["EmailConfig:Host"], Convert.ToInt32(_configuration["EmailConfig:Port"]))
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_configuration["EmailConfig:Username"], _configuration["EmailConfig:Password"]),
                    EnableSsl = true
                };
                
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailConfig:FromEmail"]),
                    Subject = subject,
                    Body = emailBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }
    }
}
