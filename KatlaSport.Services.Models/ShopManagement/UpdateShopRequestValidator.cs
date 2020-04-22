using FluentValidation;

namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateShopRequestValidator"/>
    /// </summary>
    public class UpdateShopRequestValidator : AbstractValidator<UpdateShopRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateShopRequestValidator"/> class.
        /// </summary>
        public UpdateShopRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Code).Length(5);
            RuleFor(r => r.ShopTypeId).GreaterThan(0);
        }
    }
}
