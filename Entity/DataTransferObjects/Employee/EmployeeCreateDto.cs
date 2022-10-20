using System;
namespace Entity.DataTransferObjects.Employee
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DepartmentId { get; set; }
    }
}

