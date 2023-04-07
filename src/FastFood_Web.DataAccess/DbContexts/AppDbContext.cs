using FastFood_Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFood_Web.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<CategoryEmpolyee> CategoryEmpolyees { get; set; } = default!;
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; } = default!;
        public virtual DbSet<Customer> Customers { get; set; } = default!;
        public virtual DbSet<Empolyee> Empolyees { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductStatistic> ProductStatistics { get; set; } = default!;
        public virtual DbSet<User> Users { get; set; } = default!;
    }
}
