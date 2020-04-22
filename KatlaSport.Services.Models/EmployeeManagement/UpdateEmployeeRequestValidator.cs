using FluentValidation;

namespace KatlaSport.Services.EmployeeManagement
{
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Surname).Length(4, 60);
            RuleFor(r => r.About).Length(0, 400);
        }
    }
}
