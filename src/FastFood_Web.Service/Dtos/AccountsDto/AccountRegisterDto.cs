using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FastFood_Web.Service.Dtos.AccountsDto
{
    public class AccountRegisterDto
    {
        [Required, MinLength(6), MaxLength(20)]
        public string FullName { get; set; } = String.Empty;
        [Required(AllowEmptyStrings = false), PhoneNumberAttribute]
        public string PhoneNumber { get; set; } = String.Empty;
        [Required, EmailAttribute]
        public string Email { get; set; } = String.Empty;
        [Required, MinLength(8), PasswordAttribute]
        public string Password { get; set; } = String.Empty;


        public static implicit operator User(AccountRegisterDto registerDto)
        {
            return new User()
            {
                FullName = registerDto.FullName,
                PhoneNumber = registerDto.PhoneNumber,
                Email = registerDto.Email,
                PasswordHash = registerDto.Password
            };
        }
    }
}
