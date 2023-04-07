using FastFood_Web.DataAccess.DbContexts;
using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFood_Web.DataAccess.Repositories.Common
{
    public class BaseRepositorie<T> : IRepositorie<T> where T : Base
    {
        protected AppDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepositorie(AppDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FirstByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TrackingDeteched(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(long id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
