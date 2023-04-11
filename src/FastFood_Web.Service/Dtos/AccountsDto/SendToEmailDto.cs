using FastFood_Web.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FastFood_Web.Service.Dtos.AccountsDto
{
    public class SendToEmailDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;
    }
}
