using FluentValidation.Attributes;

namespace KatlaSport.Services.EmployeeManagement
{
    [Validator(typeof(UpdateEmployeeRequestValidator))]
    public class UpdateEmployeeRequest
    {
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

        public int ShopId { get; set; }
    }
}
