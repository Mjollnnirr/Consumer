using System;
using Core.Implementations;
using Core.Services;
using DataAccess.Db;
using Entity.Entities;

namespace DataAccess.UOW;

public class UnitOfWork : IUnitOfWork
{
    private bool _isDisposed;
    private readonly AppDbContext _context;
    private IBaseEntityRepository<Employee>? _employeeRepository;
    private IBaseEntityRepository<Department>? _departmentRepository;


    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _isDisposed = false;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _isDisposed = true;
    }

    public IBaseEntityRepository<Employee> EmployeeRepository
    {
        get
        {
            if (_employeeRepository is null)
            {
                _employeeRepository = new RepositoryBase<Employee, AppDbContext>(_context);
            }
            return _employeeRepository;
        }
    }

    public IBaseEntityRepository<Department> DepartmentRepository
    {
        get
        {
            if (_departmentRepository is null)
            {
                _departmentRepository = new RepositoryBase<Department, AppDbContext>(_context);
            }
            return _departmentRepository;
        }
    }
}

