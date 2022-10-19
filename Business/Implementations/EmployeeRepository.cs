using AutoMapper;
using Business.Base;
using Business.Services;
using Core.Services;
using DataAccess.UOW;
using Entity.DataTransferObjects.Employee;
using Entity.Entities;
using Exceptions.EntityExveptions;
using Exceptions.ProgramExceptions;

namespace Business.Implementations;

public class EmployeeRepository : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public EmployeeRepository(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeGetDto> Get(int id)
    {
        var dbData = await _unitOfWork.EmployeeRepository.Get(expression: n => n.Id == id && !n.IsDeleted);
        var data = _mapper.Map<EmployeeGetDto>(dbData);
        if (data is null)
            throw new DataMappingException();
        return data;
    }

    public async Task<List<EmployeeGetDto>> GetAll()
    {
        var dbData = await _unitOfWork.EmployeeRepository.GetAll(
            expression: n => !n.IsDeleted,
            orderBy: x => x.OrderByDescending(n => n.Id));

        if (dbData is null) throw new EntityIsNullException();

        var data = _mapper.Map<List<EmployeeGetDto>>(dbData);

        if (data is null)
            throw new DataMappingException();

        return data;
    }

    public async Task Create(EmployeeCreateDto entity)
    {
        var data = _mapper.Map<Employee>(entity);
        if (data is null)
            throw new DataMappingException();
        _unitOfWork.EmployeeRepository.Create(data);
        await _unitOfWork.SaveAsync();
    }

    public Task Update(int id, Employee entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}

