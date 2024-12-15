using System.ComponentModel.DataAnnotations;

namespace BlazorASG.VitsModel.Auth
{
    public class RegisterRequest
    {

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب.")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "يجب أن تكون كلمة المرور مكونة من 6 أحرف أو أكثر.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب.")]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير متطابقين.")]
        public string ConfirmPassword { get; set; }

        [Phone(ErrorMessage = "رقم الهاتف غير صحيح.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "الدور مطلوب.")]
        public string UserRole { get; set; }

    }
}
