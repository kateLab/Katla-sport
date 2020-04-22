using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.EmployeeShop;
using KatlaSport.Services.ImageManagement;
using DbEmployee = KatlaSport.DataAccess.EmployeeShop.Employee;

namespace KatlaSport.Services.EmployeeManagement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeContext _context;

        public EmployeeService(IEmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<EmployeeListItem>> GetEmployeesAsync()
        {
            var dbEmployees = await _context.Employees.OrderBy(e => e.Id).ToArrayAsync();
            var employees = dbEmployees.Select(h => Mapper.Map<EmployeeListItem>(h)).ToList();

            return employees;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var dbEmployees = await _context.Employees.Where(s => s.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbEmployee, Employee>(dbEmployees[0]);
        }

        public async Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest)
        {
            var dbEmployee = Mapper.Map<UpdateEmployeeRequest, DbEmployee>(createRequest);
            _context.Employees.Add(dbEmployee);
            await _context.SaveChangesAsync();
            return Mapper.Map<Employee>(dbEmployee);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, UpdateEmployeeRequest updateRequest)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            Mapper.Map(updateRequest, dbEmployee);

            await _context.SaveChangesAsync();

            return Mapper.Map<Employee>(dbEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            if (dbEmployee.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatusAsync(int id, bool deletedStatus)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];
            if (dbEmployee.IsDeleted != deletedStatus)
            {
                dbEmployee.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ImageResult> UpdateEmployeePhotoAsync(int id, ImageData imageData, IImageService imageService)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];
            var imageResult = await imageService.AddAsync(imageData, dbEmployee.ImagePath);
            dbEmployee.ImagePath = imageResult.NewImagePath;
            await _context.SaveChangesAsync();
            return imageResult;
        }

        public async Task DeleteEmployeePhotoAsync(int id, IImageService imageService)
        {
            var dbEmployees = await _context.Employees.Where(e => e.Id == id).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];
            await imageService.DeleteAsync(dbEmployee.ImagePath);
            dbEmployee.ImagePath = null;
            await _context.SaveChangesAsync();
        }
    }
}
