using FluentValidation;

namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateShopTypeRequestValidator"/>
    /// </summary>
    public class UpdateShopTypeRequestValidator : AbstractValidator<UpdateShopTypeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateShopTypeRequestValidator"/> class.
        /// </summary>
        public UpdateShopTypeRequestValidator()
        {
            RuleFor(r => r.Type).Length(4, 100);
        }
    }
}
