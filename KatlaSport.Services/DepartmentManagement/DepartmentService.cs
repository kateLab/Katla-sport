using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.EmployeeDepartment;
using DbDepartment = KatlaSport.DataAccess.EmployeeDepartment.Department;

namespace KatlaSport.Services.DepartmentManagement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentContext _context;

        public DepartmentService(IDepartmentContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<DepartmentListItem>> GetDepartmentAsync()
        {
            var dbDepartments = await _context.Departments.Where(d => d.ParentId == null)
                .OrderBy(h => h.Id).ToArrayAsync();
            var parentDepartments = dbDepartments.Select(d => Mapper.Map<DepartmentListItem>(d)).ToList();

            foreach (var department in parentDepartments)
            {
                var dbChildDepartments = await _context.Departments.Where(d => d.ParentId == department.Id).ToArrayAsync();
                var childDepartments = dbChildDepartments.Select(d => Mapper.Map<Department>(d)).ToArray();
                department.ChildDepartments = childDepartments;
            }

            return parentDepartments;
        }

        public async Task<DepartmentUpdateItem> GetDepartmentAsync(int id)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == id).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbParentDepartments = await GetParentDepartmentAsync();
            var parentDepartments = dbParentDepartments.Select(dp => Mapper.Map<DepartmentSelectItem>(dp)).ToArray();
            var requiredDepartment = Mapper.Map<DepartmentUpdateItem>(dbDepartments[0]);
            requiredDepartment.ParentDepartments = parentDepartments;
            return requiredDepartment;
        }

        public async Task<List<DepartmentSelectItem>> GetParentDepartmentAsync()
        {
            var dbDepartments = await _context.Departments.Where(d => d.ParentId == null)
                .OrderBy(h => h.Id).ToArrayAsync();
            var parentDepartments = dbDepartments.Select(dp => Mapper.Map<DepartmentSelectItem>(dp)).ToList();
            return parentDepartments;
        }

        public async Task<List<DepartmentSelectItem>> GetChildDepartmentAsync(int parentId)
        {
            var dbDepartments = await _context.Departments.Where(d => d.ParentId == parentId)
                .OrderBy(h => h.Id).ToArrayAsync();
            var childDepartments = dbDepartments.Select(dp => Mapper.Map<DepartmentSelectItem>(dp)).ToList();
            return childDepartments;
        }

        public async Task SetStatusAsync(int id, bool deletedStatus)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == id).ToArrayAsync();

            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

           /* var childDepartmentsCount = await _context.Departments.Where(d => d.ParentId == id).CountAsync();
            if (childDepartmentsCount != 0)
            {
                throw new RequestedResourceHasConflictException($"Department still has child departments! {id}");
            } */

            var dbDepartment = dbDepartments[0];
            if (dbDepartment.IsDeleted != deletedStatus)
            {
                dbDepartment.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Department> CreateDepartmentAsync(UpdateDepartmentRequest createRequest)
        {
            var departmentId = createRequest.ParentId;
            if (departmentId != null)
            {
                var dbDepartments = await _context.Departments.Where(d => d.Id == departmentId).ToArrayAsync();
                if (dbDepartments.Length == 0)
                {
                    throw new RequestedResourceHasConflictException($"Cannot add new department with not existing parent {nameof(departmentId)}");
                }
            }

            var dbDepartment = Mapper.Map<UpdateDepartmentRequest, DbDepartment>(createRequest);
            _context.Departments.Add(dbDepartment);
            await _context.SaveChangesAsync();
            return Mapper.Map<Department>(dbDepartment);
        }

        public async Task<Department> UpdateDepartmentAsync(int id, UpdateDepartmentRequest updateRequest)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == id).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];

            var parentDepartmentId = updateRequest.ParentId;
            if (parentDepartmentId != null)
            {
                var parentDepartments = await _context.Departments.Where(d => d.ParentId == parentDepartmentId).ToArrayAsync();
                if (parentDepartments.Length == 0)
                {
                    throw new RequestedResourceHasConflictException($"Cannot add new department with not existing parent {nameof(parentDepartmentId)}");
                }
            }

            Mapper.Map(updateRequest, dbDepartment);
            await _context.SaveChangesAsync();
            return Mapper.Map<Department>(dbDepartment);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var dbDepartments = await _context.Departments.Where(d => d.Id == id).ToArrayAsync();
            if (dbDepartments.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDepartment = dbDepartments[0];
            if (dbDepartment.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Departments.Remove(dbDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
