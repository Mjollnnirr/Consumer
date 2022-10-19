using System;
using AutoMapper;
using Entity.DataTransferObjects.Department;
using Entity.DataTransferObjects.Employee;
using Entity.Entities;

namespace CommonData.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Employee
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeeCreateDto, Employee>();

            //Department
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentCreateDto, Department>();
        }
    }
}

