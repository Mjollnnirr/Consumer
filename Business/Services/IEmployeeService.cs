using System;
using Business.Base;
using Entity.DataTransferObjects.Employee;
using Entity.Entities;

namespace Business.Services;

public interface IEmployeeService
    //: IBaseService
{
    Task<EmployeeGetDto> Get(int id);
    Task<List<EmployeeGetDto>> GetAll();
    Task Create(EmployeeCreateDto entity);
    Task Update(int id, Employee entity);
    Task Delete(int id);
}

