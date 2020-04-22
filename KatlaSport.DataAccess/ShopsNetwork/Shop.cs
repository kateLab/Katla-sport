using System.Collections.Generic;
using KatlaSport.DataAccess.EmployeeShop;

namespace KatlaSport.DataAccess.ShopsNetwork
{
    /// <summary>
    /// Represents a shop.
    /// </summary>
    public class Shop
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
        /// Gets or sets a shop type Id.
        /// </summary>
        public int ShopTypeId { get; set; }

        /// <summary>
        /// Gets or sets a shop type.
        /// </summary>
        public ShopType ShopType { get; set; }

        /// <summary>
        /// Gets or sets a collection of employees for the shop.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
