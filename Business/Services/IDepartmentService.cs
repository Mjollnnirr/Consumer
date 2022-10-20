using System;
using Entity.DataTransferObjects.Department;
using Entity.DataTransferObjects.Employee;

namespace Business.Services;

public interface IDepartmentService
{
    Task<DepartmentGetDto> Get(int id);
    Task<List<DepartmentGetDto>> GetAll();
    Task<List<EmployeeGetDto>> GetEmployeesByDepartment(int id);
    Task Create(DepartmentCreateDto entity);
    Task Update(int id, DepartmentCreateDto entity);
    Task Delete(int id);
}

