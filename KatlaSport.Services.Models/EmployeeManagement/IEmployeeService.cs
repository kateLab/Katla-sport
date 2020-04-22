using System.Collections.Generic;
using System.Threading.Tasks;
using KatlaSport.Services.ImageManagement;

namespace KatlaSport.Services.EmployeeManagement
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListItem>> GetEmployeesAsync();

        Task<Employee> GetEmployeeAsync(int id);

        Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest);

        Task<Employee> UpdateEmployeeAsync(int id, UpdateEmployeeRequest updateRequest);

        Task DeleteEmployeeAsync(int id);

        Task SetStatusAsync(int id, bool deletedStatus);

        Task<ImageResult> UpdateEmployeePhotoAsync(int id, ImageData data, IImageService imageService);

        Task DeleteEmployeePhotoAsync(int id, IImageService imageService);
    }
}
