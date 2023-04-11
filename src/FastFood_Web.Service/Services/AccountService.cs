using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.Domain.Entities;
using FastFood_Web.Domain.Enums;
using FastFood_Web.Service.Common.Exceptions;
using FastFood_Web.Service.Common.Security;
using FastFood_Web.Service.Dtos.AccountsDto;
using FastFood_Web.Service.Helpers;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Interfaces.Common;
using FastFood_Web.Service.ViewModel.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace FastFood_Web.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;
        private readonly IMemoryCache _memoryCache;
        private readonly IEmailService _emailService;

        public AccountService(IUnitOfWork unitOfWork, IAuthManager authManager, IMemoryCache memoryCache, IEmailService emailService)
        {
            this._unitOfWork = unitOfWork;
            this._authManager = authManager;
            this._memoryCache = memoryCache;
            this._emailService = emailService;
        }

        public async Task<string> LoginAsync(AccountLoginDto logindto)
        {
            var emaiResult = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Email == logindto.Email);
            if (emaiResult is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found, Email is incorrect");
            }

            var userPassword = PasswordHasher.Verify(logindto.Password, emaiResult.Salt, emaiResult.PasswordHash);
            if (userPassword)
            {
                return _authManager.GenerateToken(emaiResult);
            }
            else
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Password is wrong!");
            }
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto registerDto)
        {
            var userEmail = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email);
            if (userEmail is not null)
            {
                throw new StatusCodeException(HttpStatusCode.Conflict, "Email alredy exist");
            }

            var userPhoneNumber = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.PhoneNumber == registerDto.PhoneNumber);
            if (userPhoneNumber is not null)
            {
                throw new StatusCodeException(HttpStatusCode.Conflict, "Phone number alredy exist");
            }

            var password = PasswordHasher.Hash(registerDto.Password);
            var user = (User)registerDto;
            user.PasswordHash = password.PasswordHash;
            user.Salt = password.Salt;
            user.UserRole = UserRole.Customer;
            user.CreatedAt = TimeHelper.GetCurrentServerTime();
            _unitOfWork.Users.Add(user);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task SendCodeAsync(SendToEmailDto sendToEmail)
        {
            int code = new Random().Next(100000, 999999);
            _memoryCache.Set(sendToEmail.Email, code, TimeSpan.FromMinutes(10));

            var message = new EmailMessage()
            {
                To = sendToEmail.Email,
                Subject = "Verification code",
                Body = code.ToString()
            };

            await _emailService.SendAsync(message);
        }

        public async Task<bool> UpdatePasswordAsync(PasswordUpdateDto dto)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(1);

            if (user is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            }
            else
            {
                var passwordresult = PasswordHasher.Hash(dto.Password);

                user.PasswordHash = passwordresult.PasswordHash;
                user.Salt = passwordresult.Salt;
                _unitOfWork.Users.Update(user.Id, user);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0;
            }
        }

        public async Task<bool> VerifyResetPassword(UserResetPasswordDto resetPasswordDto)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(resetPasswordDto.Email);
            if (user is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            }

            if (_memoryCache.TryGetValue(resetPasswordDto.Email, out int expectedCode) is false)
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is expired");
            }

            if (expectedCode != resetPasswordDto.Code)
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is wrong");
            }

            var newPassword = PasswordHasher.Hash(resetPasswordDto.Password);
            user.PasswordHash = newPassword.PasswordHash;
            user.Salt = newPassword.Salt;

            _unitOfWork.Users.Update(user.Id, user);

            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}


