using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ShopsNetwork
{
    internal sealed class ShopTypeConfiguration : EntityTypeConfiguration<ShopType>
    {
        public ShopTypeConfiguration()
        {
            ToTable("shop_type");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("shop_type_id");
            Property(i => i.Type).HasColumnName("shop_type_value");
        }
    }
}
