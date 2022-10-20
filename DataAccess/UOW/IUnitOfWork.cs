using Core.Services;
using Entity.Entities;

namespace DataAccess.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseEntityRepository<Employee> EmployeeRepository { get; }
        IBaseEntityRepository<Department> DepartmentRepository { get; }
        IBaseEntityRepository<EmployeeDepartment> EmployeeDepartmentRepository { get; }

        Task SaveAsync();
    }
}

