using EFExamples.Models.ValueTypes;
using System;
using System.Collections.Generic;

namespace EFExamples.Models.Entities
{
    public class Employee : Entity
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public Guid EmployeeId { get; private set; }

        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PersonName Name { get; set; }

        public Company Company { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
    }
}
