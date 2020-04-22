using KatlaSport.DataAccess.ShopsNetwork;

namespace KatlaSport.DataAccess.EmployeeShop
{
    internal class EmployeeContext : DomainContextBase<ApplicationDbContext>, IEmployeeContext
    {
        public EmployeeContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Employee> Employees => GetDbSet<Employee>();

        public IEntitySet<Shop> Shops => GetDbSet<Shop>();
    }
}
