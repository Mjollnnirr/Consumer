using System;
using Entity.Base;

namespace Entity.Entities;

public class Employee : BaseEntity, IEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

