using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.Entities
{
    public class Department : Entity
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public Company Company { get; set; }
        public ICollection<DepartmentContractor> DepartmentContractors { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
