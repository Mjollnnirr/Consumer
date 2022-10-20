using System;
using Entity.Base;

namespace Entity.Entities
{
    public class EmployeeDepartment : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}

