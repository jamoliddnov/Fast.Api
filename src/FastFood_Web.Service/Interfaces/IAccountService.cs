using FastFood_Web.Service.Dtos.AccountsDto;

namespace FastFood_Web.Service.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AccountRegisterDto registerDto);
        Task<string> LoginAsync(AccountLoginDto logindto);
    }
}
