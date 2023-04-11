using FastFood_Web.Domain.Common;
using System.Linq.Expressions;

namespace FastFood_Web.DataAccess.Interfaces.Common
{
    public interface IRepositorie<T> where T : Base
    {
        public Task<T?> FindByIdAsync(long id);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        public T Add(T entity);
        public void Delete(long id);
        public void TrackingDeteched(T entity);
        public void Update(long id, T entity);
    }
}