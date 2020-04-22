namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Partial class
    /// </summary>
    public partial class AddEmployeeAndDepartmentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee_department",
                c => new
                    {
                        employee_department_id = c.Int(nullable: false, identity: true),
                        employee_department_name = c.String(maxLength: 40),
                        employee_department_description = c.String(maxLength: 200),
                        deleted = c.Boolean(nullable: false),
                        parent_department_id = c.Int(),
                    })
                .PrimaryKey(t => t.employee_department_id)
                .ForeignKey("dbo.employee_department", t => t.parent_department_id)
                .Index(t => t.parent_department_id);

            CreateTable(
                "dbo.employee",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_name = c.String(),
                        employee_surname = c.String(),
                        employee_about = c.String(),
                        deleted = c.Boolean(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.employee_department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.employee", "DepartmentId", "dbo.employee_department");
            DropForeignKey("dbo.employee_department", "parent_department_id", "dbo.employee_department");
            DropIndex("dbo.employee", new[] { "DepartmentId" });
            DropIndex("dbo.employee_department", new[] { "parent_department_id" });
            DropTable("dbo.employee");
            DropTable("dbo.employee_department");
        }
    }
}
