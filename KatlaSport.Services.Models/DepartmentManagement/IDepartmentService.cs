using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.DepartmentManagement
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Gets a department list.
        /// </summary>
        /// <returns>A <see cref="Task{List{DepartmentListItem}}"/>.</returns>
        Task<List<DepartmentListItem>> GetDepartmentAsync();

        /// <summary>
        /// Gets a department with specified identifier.
        /// </summary>
        /// <param name="id">A department identifier.</param>
        /// <returns>A <see cref="Task{DepartmentUpdateItem}"/>.</returns>
        Task<DepartmentUpdateItem> GetDepartmentAsync(int id);

        Task<List<DepartmentSelectItem>> GetParentDepartmentAsync();

        Task<List<DepartmentSelectItem>> GetChildDepartmentAsync(int parentId);

        Task SetStatusAsync(int id, bool deletedStatus);

        Task<Department> CreateDepartmentAsync(UpdateDepartmentRequest createRequest);

        Task<Department> UpdateDepartmentAsync(int id, UpdateDepartmentRequest updateRequest);

        Task DeleteDepartmentAsync(int id);
    }
}
