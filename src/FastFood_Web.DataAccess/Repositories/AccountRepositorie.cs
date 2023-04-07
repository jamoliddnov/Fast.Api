using FastFood_Web.DataAccess.DbContexts;
using FastFood_Web.DataAccess.Interfaces;
using FastFood_Web.DataAccess.Repositories.Common;
using FastFood_Web.Domain.Entities;

namespace FastFood_Web.DataAccess.Repositories
{
    public class AccountRepositorie : GenericRepositorie<User>, IAccountRepositorie
    {
        public AccountRepositorie(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}