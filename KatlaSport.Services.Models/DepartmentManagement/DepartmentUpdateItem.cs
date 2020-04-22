namespace KatlaSport.Services.DepartmentManagement
{
    public class DepartmentUpdateItem
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

        public int? ParentDepartmentId { get; set; }

        public DepartmentSelectItem[] ParentDepartments { get; set; } = new DepartmentSelectItem[] { };
    }
}
