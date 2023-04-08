using FastFood_Web.Service.Dtos.AccountsDto;
using FastFood_Web.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFood_Web.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> AccountRegister([FromForm] AccountRegisterDto registerDto)
        {
            return Ok(await _accountService.RegisterAsync(registerDto));
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginRegister([FromForm] AccountLoginDto accountLogindto)
        {
            return Ok(await _accountService.LoginAsync(accountLogindto));
        }



    }
}
