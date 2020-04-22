namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Partial class.
    /// </summary>
    public partial class AddShopTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.shop_type",
                c => new
                    {
                        shop_type_id = c.Int(nullable: false, identity: true),
                        shop_type_value = c.String(),
                    })
                .PrimaryKey(t => t.shop_type_id);

            AddColumn("dbo.shop", "ShopTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.shop", "ShopTypeId");
            AddForeignKey("dbo.shop", "ShopTypeId", "dbo.shop_type", "shop_type_id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.shop", "ShopTypeId", "dbo.shop_type");
            DropIndex("dbo.shop", new[] { "ShopTypeId" });
            DropColumn("dbo.shop", "ShopTypeId");
            DropTable("dbo.shop_type");
        }
    }
}
