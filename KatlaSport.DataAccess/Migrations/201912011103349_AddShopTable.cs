namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Partial class
    /// </summary>
    public partial class AddShopTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.shop",
                c => new
                    {
                        shop_id = c.Int(nullable: false, identity: true),
                        shop_name = c.String(maxLength: 40),
                        shop_code = c.String(maxLength: 5),
                        shop_address = c.String(maxLength: 300),
                        shop_description = c.String(maxLength: 400),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.shop_id);
        }

        public override void Down()
        {
            DropTable("dbo.shop");
        }
    }
}
