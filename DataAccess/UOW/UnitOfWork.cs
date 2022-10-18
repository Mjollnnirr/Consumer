using System;
using Core.Implementations;
using Core.Services;
using DataAccess.Db;
using Entity.Entities;

namespace DataAccess.UOW
{
    public class UnitOfWork : IDisposable
    {
        private bool _isDisposed;
        private AppDbContext _context;
        private IBaseEntityRepository<Employee>? _employeeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _isDisposed = false;
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

        public async void Save()
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
    }
}

