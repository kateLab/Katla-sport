namespace KatlaSport.Services.DepartmentManagement
{
    public class DepartmentListItem
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

        public Department[] ChildDepartments { get; set; } = new Department[] { };
    }
}
