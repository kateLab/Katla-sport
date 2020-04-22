namespace KatlaSport.DataAccess.EmployeeDepartment
{
    /// <summary>
    /// Represents a context for department domain
    /// </summary>
    public interface IDepartmentContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Department"/> entities
        /// </summary>
        IEntitySet<Department> Departments { get; }
    }
}
