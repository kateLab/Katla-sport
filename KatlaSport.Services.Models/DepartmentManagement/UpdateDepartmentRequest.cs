using FluentValidation.Attributes;

namespace KatlaSport.Services.DepartmentManagement
{
    [Validator(typeof(UpdateDepartmentRequestValidator))]
    public class UpdateDepartmentRequest
    {
        /// <summary>
        /// Gets or sets a department name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a department description.
        /// </summary>
        public string Description { get; set; }

        public int? ParentId { get; set; }
    }
}
