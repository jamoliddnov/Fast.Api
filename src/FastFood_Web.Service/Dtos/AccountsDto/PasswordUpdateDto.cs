using FastFood_Web.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FastFood_Web.Service.Dtos.AccountsDto
{
    public class PasswordUpdateDto
    {
        [Required, PasswordAttribute]
        public string Password { get; set; } = String.Empty;
    }
}
