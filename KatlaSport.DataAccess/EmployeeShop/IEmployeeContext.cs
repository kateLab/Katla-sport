using KatlaSport.DataAccess.ShopsNetwork;

namespace KatlaSport.DataAccess.EmployeeShop
{
    /// <summary>
    /// Represents a context for employee domain
    /// </summary>
    public interface IEmployeeContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Employee"/> entities
        /// </summary>
        IEntitySet<Employee> Employees { get; }

        /// <summary>
        /// Gets a set of <see cref="Shop"/> entities.
        /// </summary>
        IEntitySet<Shop> Shops { get; }
    }
}
