using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents a shop service.
    /// </summary>
    public interface IShopService
    {
        /// <summary>
        /// Gets a list of shops.
        /// </summary>
        /// <returns>A <see cref="Task{List{ShopListItem}}"/>.</returns>
        Task<List<ShopListItem>> GetShopsAsync();

        /// <summary>
        /// Gets a shop.
        /// </summary>
        /// <param name="id">A shop identifier.</param>
        /// <returns>A <see cref="Task{Shop}"/>.</returns>
        Task<Shop> GetShopAsync(int id);

        /// <summary>
        /// Gets a list of hive sections for specified hive.
        /// </summary>
        /// <param name="shopTypeId">A hive identifier.</param>
        /// <returns>A <see cref="Task{List{ShopListItem}}"/>.</returns>
        Task<List<ShopListItem>> GetShopsAsync(int shopTypeId);

        /// <summary>
        /// Sets deleted status for a shop.
        /// </summary>
        /// <param name="shopId">A shop identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int shopId, bool deletedStatus);

        /// <summary>
        /// Creates a new shop.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateShopRequest"/>.</param>
        /// <returns>A <see cref="Task{Shop}"/>.</returns>
        Task<Shop> CreateShopAsync(UpdateShopRequest createRequest);

        /// <summary>
        /// Updates an existed shop.
        /// </summary>
        /// <param name="shopId">A shop identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateShopRequest"/>.</param>
        /// <returns>A <see cref="Task{Hive}"/>.</returns>
        Task<Shop> UpdateShopAsync(int shopId, UpdateShopRequest updateRequest);

        /// <summary>
        /// Deletes an existed shop.
        /// </summary>
        /// <param name="shopId">A shop identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteShopAsync(int shopId);
    }
}
