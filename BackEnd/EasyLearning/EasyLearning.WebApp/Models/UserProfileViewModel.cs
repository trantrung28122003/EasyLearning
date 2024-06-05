using System.ComponentModel.DataAnnotations;

namespace EasyLearning.WebApp.Models
{
    public class UserProfileViewModel
    {
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Avatar {  get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Password { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
