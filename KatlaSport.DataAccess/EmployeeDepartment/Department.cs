namespace KatlaSport.DataAccess.EmployeeDepartment
{
    /// <summary>
    /// Represents a department.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Gets or sets a department ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a department name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a department description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a department is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a parent ID.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a parent departament.
        /// </summary>
        public Department ParentDepartment { get; set; }
    }
}
