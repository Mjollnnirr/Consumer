using System;
using Entity.Base;

namespace Entity.Entities
{
    public class Department : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public List<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}

