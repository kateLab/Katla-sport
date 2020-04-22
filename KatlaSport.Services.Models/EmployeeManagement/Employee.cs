namespace KatlaSport.Services.EmployeeManagement
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets an employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets an employee name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an employee surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets an employee about.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an employee is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        public string ImagePath { get; set; }
    }
}
