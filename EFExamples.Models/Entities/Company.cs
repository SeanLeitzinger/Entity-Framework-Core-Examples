using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
