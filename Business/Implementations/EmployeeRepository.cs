using System;
using Business.Services;
using Core.Services;
using DataAccess.UOW;
//using DataAccess.DbServices;
using Entity.Entities;
using Exceptions.EntityExveptions;

namespace Business.Implementations
{
    public class EmployeeRepository : IEmployeeService
    {
        //private readonly IEmployeeDb _employeeDb;
        private UnitOfWork _unitOfWork;
        private readonly IBaseEntityRepository<Employee> repository;
        public EmployeeRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            repository = _unitOfWork.EmployeeRepository;
        }

        public async Task<Employee> Get(int id)
        {
            //var data = await _employeeDb.Get(n => n.Id == id && !n.IsDeleted);
            var data = await repository.Get(n => n.Id == id);
            return data;
        }

        public async Task<List<Employee>> GetAll()
        {
            //var data = await _employeeDb.GetAll(n => !n.IsDeleted);
            var data = await repository.GetAll(n => !n.IsDeleted, x => x.OrderByDescending(n => n.Id));
            if (data is null) throw new EntityIsNullException();
            return data;
        }

        public Task Create(Employee data)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Employee data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

