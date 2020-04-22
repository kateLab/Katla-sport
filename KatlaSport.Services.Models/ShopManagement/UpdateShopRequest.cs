using FluentValidation.Attributes;

namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents a request for creating and updating a shop.
    /// </summary>
    [Validator(typeof(UpdateShopRequestValidator))]
    public class UpdateShopRequest
    {
        /// <summary>
        /// Gets or sets a shop name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a shop code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a shop address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a shop description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a shop type identifier.
        /// </summary>
        public int ShopTypeId { get; set; }
    }
}
