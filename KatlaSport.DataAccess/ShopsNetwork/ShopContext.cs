namespace KatlaSport.DataAccess.ShopsNetwork
{
    internal class ShopContext : DomainContextBase<ApplicationDbContext>, IShopContext
    {
        public ShopContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Shop> Shops => GetDbSet<Shop>();

        public IEntitySet<ShopType> ShopTypes => GetDbSet<ShopType>();
    }
}
