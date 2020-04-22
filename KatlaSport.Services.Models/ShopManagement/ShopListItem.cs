namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents a shop list item.
    /// </summary>
    public class ShopListItem
    {
        /// <summary>
        /// Gets or sets a shop Id.
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets a value indicating whether a shop is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a shop type identifier.
        /// </summary>
        public int ShopTypeId { get; set; }
    }
}
