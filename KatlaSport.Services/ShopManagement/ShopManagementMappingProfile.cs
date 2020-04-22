using AutoMapper;
using DataAccessShop = KatlaSport.DataAccess.ShopsNetwork.Shop;
using DataAccessShopType = KatlaSport.DataAccess.ShopsNetwork.ShopType;

namespace KatlaSport.Services.ShopManagement
{
    public sealed class ShopManagementMappingProfile : Profile
    {
        public ShopManagementMappingProfile()
        {
            CreateMap<DataAccessShopType, ShopTypeListItem>();
            CreateMap<DataAccessShopType, ShopType>();
            CreateMap<UpdateShopTypeRequest, DataAccessShopType>();
            CreateMap<DataAccessShop, ShopListItem>();
            CreateMap<DataAccessShop, Shop>();
            CreateMap<UpdateShopRequest, DataAccessShop>();
            CreateMap<ShopType, UpdateShopTypeRequest>();
        }
    }
}
