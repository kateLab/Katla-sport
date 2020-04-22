using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.EmployeeDepartment
{
    internal sealed class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("employee_department");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("employee_department_id");
            Property(i => i.Name).HasColumnName("employee_department_name").HasMaxLength(40);
            Property(i => i.Description).HasColumnName("employee_department_description").HasMaxLength(200);
            Property(i => i.ParentId).HasColumnName("parent_department_id");
            Property(i => i.IsDeleted).HasColumnName("deleted");
            HasOptional(i => i.ParentDepartment).WithMany().HasForeignKey(i => i.ParentId);
        }
    }
}
