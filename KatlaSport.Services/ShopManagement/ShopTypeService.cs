using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ShopsNetwork;
using DbShopType = KatlaSport.DataAccess.ShopsNetwork.ShopType;

namespace KatlaSport.Services.ShopManagement
{
    public class ShopTypeService : IRepository<ShopType>
    {
        private readonly IShopContext _context;

        public ShopTypeService(IShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<ShopType>> GetShopTypesAsync()
        {
            var dbShopTypes = await _context.ShopTypes.OrderBy(h => h.Id).ToArrayAsync();
            var shopTypes = dbShopTypes.Select(h => Mapper.Map<ShopType>(h)).ToList();

            return shopTypes;
        }

        /// <inheritdoc/>
        public async Task<ShopType> GetShopTypeAsync(int shopTypeId)
        {
            var dbShopTypes = await _context.ShopTypes.Where(h => h.Id == shopTypeId).ToArrayAsync();

            if (dbShopTypes.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbShopType, ShopType>(dbShopTypes[0]);
        }

        /// <inheritdoc/>
        public async Task CreateShopTypeAsync(ShopType shopType)
        {
            var createShopType = Mapper.Map<ShopType, UpdateShopTypeRequest>(shopType);
            var dbShopType = Mapper.Map<UpdateShopTypeRequest, DbShopType>(createShopType);
            _context.ShopTypes.Add(dbShopType);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateShopTypeAsync(ShopType shopType)
        {
            var dbShopTypes = await _context.ShopTypes.Where(p => p.Id == shopType.Id).ToArrayAsync();
            if (dbShopTypes.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbShopType = dbShopTypes[0];

            var updateShopType = Mapper.Map<ShopType, UpdateShopTypeRequest>(shopType);

            Mapper.Map(updateShopType, dbShopType);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteShopTypeAsync(ShopType shopType)
        {
            var dbShopTypes = await _context.ShopTypes.Where(p => p.Id == shopType.Id).ToArrayAsync();
            if (dbShopTypes.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbShopType = dbShopTypes[0];

            _context.ShopTypes.Remove(dbShopType);
            await _context.SaveChangesAsync();
        }
    }
}
