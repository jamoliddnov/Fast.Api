using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.Domain.Entities;
using FastFood_Web.Domain.Enums;
using FastFood_Web.Service.Common.Exceptions;
using FastFood_Web.Service.Common.Security;
using FastFood_Web.Service.Dtos.AccountsDto;
using FastFood_Web.Service.Helpers;
using FastFood_Web.Service.Interfaces;
using System.Net;

namespace FastFood_Web.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> LoginAsync(AccountLoginDto logindto)
        {
            return false;
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
            _unitOfWork.Users.Create(user);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }
    }
}