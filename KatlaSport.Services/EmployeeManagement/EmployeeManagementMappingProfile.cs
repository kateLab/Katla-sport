using AutoMapper;
using DataAccessEmployee = KatlaSport.DataAccess.EmployeeShop.Employee;

namespace KatlaSport.Services.EmployeeManagement
{
    public sealed class EmployeeManagementMappingProfile : Profile
    {
        public EmployeeManagementMappingProfile()
        {
            CreateMap<DataAccessEmployee, Employee>();
            CreateMap<DataAccessEmployee, EmployeeListItem>();
            CreateMap<UpdateEmployeeRequest, DataAccessEmployee>();
        }
    }
}
