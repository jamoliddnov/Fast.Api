namespace FastFood_Web.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAccountRepositorie Users { get; }
        public ICategoryEmpolyeeRepositorie CategoryEmpolyees { get; }
        public ICategoryProductRepositorie CategoryProducts { get; }
        public ICustomerRepositorie Customers { get; }
        public IEmpolyeeRepositorie Empolyees { get; }
        public IOrderRepositorie Orders { get; }
        public IProductRepositorie Products { get; }
        public IProductStatisticRepositorie ProductStatistics { get; }

        public Task<int> SaveChangesAsync();
    }
}
