using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.Domain.Entities;
using FastFood_Web.Domain.Enums;
using FastFood_Web.Service.Common.Exceptions;
using FastFood_Web.Service.Common.Security;
using FastFood_Web.Service.Dtos.AccountsDto;
using FastFood_Web.Service.Helpers;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Interfaces.Common;
using System.Net;

namespace FastFood_Web.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;

        public AccountService(IUnitOfWork unitOfWork , IAuthManager authManager)
        {
            this._unitOfWork = unitOfWork;
            this._authManager = authManager;

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
    }
}