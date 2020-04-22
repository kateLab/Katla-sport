using FluentValidation.Attributes;

namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents a request for creating and updating a shop type.
    /// </summary>
    [Validator(typeof(UpdateShopTypeRequestValidator))]
    public class UpdateShopTypeRequest
    {
        /// <summary>
        /// Gets or sets a type.
        /// </summary>
        public string Type { get; set; }
    }
}
