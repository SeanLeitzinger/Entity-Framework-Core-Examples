using EFExamples.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.Entities
{
    public class Contractor : Entity
    {
        public int DepartmentId { get; set; }
        public int VendorId { get; set; }

        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PersonName Name { get; set; }
        
        public Department Department { get; set; }
        public Vendor Vendor { get; set; }
    }
}
