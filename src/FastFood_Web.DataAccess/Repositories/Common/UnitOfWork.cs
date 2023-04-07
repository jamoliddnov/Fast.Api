using FastFood_Web.DataAccess.DbContexts;
using FastFood_Web.DataAccess.Interfaces;
using FastFood_Web.DataAccess.Interfaces.Common;

namespace FastFood_Web.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IAccountRepositorie Users { get; }

        public ICategoryEmpolyeeRepositorie CategoryEmpolyees { get; }

        public ICategoryProductRepositorie CategoryProducts { get; }

        public ICustomerRepositorie Customers { get; }

        public IEmpolyeeRepositorie Empolyees { get; }

        public IOrderRepositorie Orders { get; }

        public IProductRepositorie Products { get; }

        public IProductStatisticRepositorie ProductStatistics { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Users = new AccountRepositorie(appDbContext);
            CategoryEmpolyees = new CategoryEmpolyeeRepositprie(appDbContext);
            CategoryProducts = new CategoryProductRepositorie(appDbContext);
            Customers = new CustomerRepository(appDbContext);
            Empolyees = new EmpolyeeRepository(appDbContext);
            Orders = new OrderRepository(appDbContext);
            Products = new ProductRepository(appDbContext);
            ProductStatistics = new ProductStatisticRepository(appDbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }
    }
}
