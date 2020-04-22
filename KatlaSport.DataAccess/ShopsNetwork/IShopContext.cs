namespace KatlaSport.DataAccess.ShopsNetwork
{
    /// <summary>
    /// Represents a context for shop domain
    /// </summary>
    public interface IShopContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Shop"/> entities.
        /// </summary>
        IEntitySet<Shop> Shops { get; }

        /// <summary>
        /// Gets a set of <see cref="ShopType"/> entities.
        /// </summary>
        IEntitySet<ShopType> ShopTypes { get; }
    }
}
