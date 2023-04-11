using FastFood_Web.Service.Dtos.AccountsDto;

namespace FastFood_Web.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(AccountRegisterDto registerDto);
        public Task<string> LoginAsync(AccountLoginDto logindto);

        public Task<bool> VerifyResetPassword(UserResetPasswordDto resetPasswordDto);

        public Task SendCodeAsync(SendToEmailDto sendTo);

        public Task<bool> UpdatePasswordAsync(PasswordUpdateDto dto);
    }
}
