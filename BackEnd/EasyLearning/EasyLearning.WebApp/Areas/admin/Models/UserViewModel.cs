namespace EasyLearning.WebApp.Areas.admin.Models
{
    public class UserViewModel
    {
        public string? UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public List<string>? Roles { get; set; }

    }
}
