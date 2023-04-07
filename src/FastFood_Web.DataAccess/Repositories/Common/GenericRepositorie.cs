using FastFood_Web.DataAccess.DbContexts;
using FastFood_Web.DataAccess.Interfaces.Common;
using FastFood_Web.Domain.Common;
using System.Linq.Expressions;

namespace FastFood_Web.DataAccess.Repositories.Common
{
    public class GenericRepositorie<T> : BaseRepositorie<T>, IGenericRepositorie<T> where T : Base
    {
        public GenericRepositorie(AppDbContext dbContext)
            : base(dbContext)
        {

        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}

