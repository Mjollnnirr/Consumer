using System;
using Entity.DataTransferObjects.Department;

namespace Business.Services;

public interface IDepartmentService
{
    Task<DepartmentGetDto> Get(int id);
    Task<List<DepartmentGetDto>> GetAll();
    Task Create(DepartmentCreateDto entity);
    Task Update(int id, DepartmentCreateDto entity);
    Task Delete(int id);
}

