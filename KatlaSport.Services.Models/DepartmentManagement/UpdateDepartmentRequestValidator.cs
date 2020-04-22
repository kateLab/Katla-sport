using FluentValidation;

namespace KatlaSport.Services.DepartmentManagement
{
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Description).Length(0, 300);
        }
    }
}
