using FastFood_Web.DataAccess.DbContexts;
using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.DataAccess.Repositories.Common;
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

        public virtual T Add(T entity)
        {
            var res =  _dbSet.Add(entity);
            return res.Entity;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FirstByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
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



//public virtual T Add(T entity) => _dbSet.Add(entity).Entity;

//public virtual void Delete(long id)
//{
//    var entity = _dbSet.Find(id);
//    if (entity is not null)
//        _dbSet.Remove(entity);
//}

//public virtual async Task<T?> FindByIdAsync(long id)
//{

//    return await _dbSet.FindAsync(id);
//}

//public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
//{
//    return await _dbSet.FirstOrDefaultAsync(expression);
//}

//public void TrackingDeteched(T entity)
//{
//    _dbContext.Entry<T>(entity!).State = EntityState.Detached;
//}

//public virtual void Update(long id, T entity)
//{
//    entity.Id = id;
//    _dbSet.Update(entity);
//}