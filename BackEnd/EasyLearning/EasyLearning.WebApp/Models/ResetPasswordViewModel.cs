using System.ComponentModel.DataAnnotations;

namespace EasyLearning.WebApp.Models
{
    public class ResetPasswordViewModel
    {
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Mã xác minh phải có đúng 6 chữ số.")]
        public string? VerificationCode { get; set; }

        public string? HiddenSendVerificationCode { get; set; }
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password là bắt buộc")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password phải có ít nhất 8 ký tự và bao gồm ít nhất một chữ cái thường, một chữ cái hoa, một số và một ký tự đặc biệt.")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password là bắt buộc")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string? ConfirmPassword { get; set; }
    }
}
