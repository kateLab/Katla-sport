namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Partial class
    /// </summary>
    public partial class AddImagePathToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.employee", "ImagePath", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.employee", "ImagePath");
        }
    }
}
