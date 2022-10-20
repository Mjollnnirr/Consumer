using System;
using AutoMapper;
using Business.Services;
using Core.Services;
using DataAccess.UOW;
using Entity.DataTransferObjects.Department;
using Entity.DataTransferObjects.Employee;
using Entity.Entities;
using Exceptions.EntityExveptions;
using Exceptions.ProgramExceptions;

namespace Business.Implementations
{
    public class DepartmentRepository : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentGetDto> Get(int id)
        {
            var dbData = await _unitOfWork.DepartmentRepository.Get(
                expression: n => n.Id == id && !n.IsDeleted);
            if (dbData is null)
                throw new EntityIsNullException();
            var data = _mapper.Map<DepartmentGetDto>(dbData);
            if (data is null)
                throw new DataMappingException();
            return data;
        }

        public async Task<List<DepartmentGetDto>> GetAll()
        {
            var dbData = await _unitOfWork.DepartmentRepository.GetAll(
                expression: n => !n.IsDeleted);
            if (dbData is null)
                throw new EntityIsNullException();
            var data = _mapper.Map<List<DepartmentGetDto>>(dbData);
            if (data is null)
                throw new DataMappingException();
            return data;
        }

        public async Task<List<EmployeeGetDto>> GetEmployeesByDepartment(int id)
        {
            var dbData = (await _unitOfWork.EmployeeDepartmentRepository.GetAll(
                expression: n => n.DepartmentId == id,
                includes: new string[] { "Employee" })).Select(n => n.Employee);
            if (dbData is null)
            {
                throw new EntityIsNullException();
            }

            var data = _mapper.Map<List<EmployeeGetDto>>(dbData);

            return data;
        }

        public async Task Create(DepartmentCreateDto entity)
        {
            var data = _mapper.Map<Department>(entity);

            if (data is null)
                throw new DataMappingException();
            _unitOfWork.DepartmentRepository.Create(data);
            await _unitOfWork.SaveAsync();
        }

        public Task Update(int id, DepartmentCreateDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

