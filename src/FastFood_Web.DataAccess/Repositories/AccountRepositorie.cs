using FastFood_Web.DataAccess.DbContexts;
using FastFood_Web.DataAccess.Interfaces;
using FastFood_Web.DataAccess.Repositories.Common;
using FastFood_Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFood_Web.DataAccess.Repositories
{
    public class AccountRepositorie : GenericRepositorie<User>, IAccountRepositorie
    {
        public AccountRepositorie(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}