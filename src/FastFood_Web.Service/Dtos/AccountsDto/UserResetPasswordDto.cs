using FastFood_Web.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FastFood_Web.Service.Dtos.AccountsDto
{
    public class UserResetPasswordDto
    {
        [Required(ErrorMessage = "Email is required!"), EmailAttribute]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Code { get; set; }

        [Required, PasswordAttribute]
        public string Password { get; set; } = string.Empty;
    }
}
