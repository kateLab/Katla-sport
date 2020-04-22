using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ShopManagement
{
    /// <summary>
    /// Represents repository pattern
    /// </summary>
    /// <typeparam name="TEntity">class</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets a list of shop type.
        /// </summary>
        /// <returns>A <see cref="Task{List{TEntity}}"/>.</returns>
        Task<List<TEntity>> GetShopTypesAsync();

        /// <summary>
        /// Get a shop type.
        /// </summary>
        /// <param name="id">A shop type identifier.</param>
        /// <returns>A <see cref="Task{TEntity}"/>.</returns>
        Task<TEntity> GetShopTypeAsync(int id);

        /// <summary>
        /// Creates a new shop type.
        /// </summary>
        /// <param name="entity">shop type</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task CreateShopTypeAsync(TEntity entity);

        /// <summary>
        /// Updates an existed shop type.
        /// </summary>
        /// <param name="entity">shop type</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateShopTypeAsync(TEntity entity);

        /// <summary>
        /// Deletes an existed shop type.
        /// </summary>
        /// <param name="entity">shop type</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteShopTypeAsync(TEntity entity);
    }
}
