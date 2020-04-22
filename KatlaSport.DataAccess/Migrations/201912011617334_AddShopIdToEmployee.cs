namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Partial class
    /// </summary>
    public partial class AddShopIdToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee", "employee_shop_id", c => c.Int(nullable: false));
            CreateIndex("dbo.employee", "employee_shop_id");
            AddForeignKey("dbo.employee", "employee_shop_id", "dbo.shop", "shop_id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.employee", "employee_shop_id", "dbo.shop");
            DropIndex("dbo.employee", new[] { "employee_shop_id" });
            DropColumn("dbo.employee", "employee_shop_id");
        }
    }
}
