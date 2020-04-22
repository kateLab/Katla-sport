using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ShopsNetwork;
using DbShop = KatlaSport.DataAccess.ShopsNetwork.Shop;

namespace KatlaSport.Services.ShopManagement
{
    public class ShopService : IShopService
    {
        private readonly IShopContext _context;

        public ShopService(IShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<ShopListItem>> GetShopsAsync()
        {
            var sbShops = await _context.Shops.OrderBy(s => s.Id).ToArrayAsync();
            var shop = sbShops.Select(s => Mapper.Map<ShopListItem>(s)).ToList();
            return shop;
        }

        /// <inheritdoc/>
        public async Task<Shop> GetShopAsync(int id)
        {
            var dbShops = await _context.Shops.Where(s => s.Id == id).ToArrayAsync();
            if (dbShops.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbShop, Shop>(dbShops[0]);
        }

        /// <inheritdoc/>
        public async Task<List<ShopListItem>> GetShopsAsync(int shopTypeId)
        {
            var dbShops = await _context.Shops.Where(s => s.ShopTypeId == shopTypeId).OrderBy(s => s.Id).ToArrayAsync();
            var shops = dbShops.Select(s => Mapper.Map<ShopListItem>(s)).ToList();
            return shops;
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int shopId, bool deletedStatus)
        {
            var dbShops = await _context.Shops.Where(s => s.Id == shopId).ToArrayAsync();

            if (dbShops.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbShop = dbShops[0];
            if (dbShop.IsDeleted != deletedStatus)
            {
                dbShop.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<Shop> CreateShopAsync(UpdateShopRequest createRequest)
        {
            var dbShops = await _context.Shops.Where(c => c.Code == createRequest.Code).ToArrayAsync();
            if (dbShops.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbShop = Mapper.Map<UpdateShopRequest, DbShop>(createRequest);
            _context.Shops.Add(dbShop);

            await _context.SaveChangesAsync();

            return Mapper.Map<Shop>(dbShop);
        }

        /// <inheritdoc/>
        public async Task<Shop> UpdateShopAsync(int shopId, UpdateShopRequest updateRequest)
        {
            var dbShops = await _context.Shops.Where(c => c.Code == updateRequest.Code && c.Id != shopId).ToArrayAsync();
            if (dbShops.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbShops = await _context.Shops.Where(c => c.Id == shopId).ToArrayAsync();
            if (dbShops.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbShop = dbShops[0];

            Mapper.Map(updateRequest, dbShop);

            await _context.SaveChangesAsync();

            return Mapper.Map<Shop>(dbShop);
        }

        /// <inheritdoc/>
        public async Task DeleteShopAsync(int shopId)
        {
            var dbShops = await _context.Shops.Where(c => c.Id == shopId).ToArrayAsync();
            if (dbShops.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbShop = dbShops[0];
            if (!dbShop.IsDeleted)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Shops.Remove(dbShop);
            await _context.SaveChangesAsync();
        }
    }
}
