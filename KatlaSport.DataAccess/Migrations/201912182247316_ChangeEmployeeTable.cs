namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Partial class
    /// </summary>
    public partial class ChangeEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.employee", "DepartmentId", "dbo.employee_department");
            DropIndex("dbo.employee", new[] { "DepartmentId" });
            DropColumn("dbo.employee", "DepartmentId");
        }

        public override void Down()
        {
            AddColumn("dbo.employee", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.employee", "DepartmentId");
            AddForeignKey("dbo.employee", "DepartmentId", "dbo.employee_department", "employee_department_id", cascadeDelete: true);
        }
    }
}
