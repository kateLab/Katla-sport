using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ShopsNetwork
{
    internal sealed class ShopConfiguration : EntityTypeConfiguration<Shop>
    {
        public ShopConfiguration()
        {
            ToTable("shop");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("shop_id");
            Property(i => i.Name).HasColumnName("shop_name").HasMaxLength(40);
            Property(i => i.Code).HasColumnName("shop_code").HasMaxLength(5);
            Property(i => i.Address).HasColumnName("shop_address").HasMaxLength(300);
            Property(i => i.Description).HasColumnName("shop_description").HasMaxLength(400);
            Property(i => i.IsDeleted).HasColumnName("deleted");
            HasRequired(i => i.ShopType).WithMany().HasForeignKey(i => i.ShopTypeId);
        }
    }
}
