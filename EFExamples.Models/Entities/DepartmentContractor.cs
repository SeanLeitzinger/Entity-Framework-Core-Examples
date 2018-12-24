using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.Entities
{
    public class DepartmentContractor
    {
        public int ContractorId { get; set; }
        public int DepartmentId { get; set; }

        public Contractor Contractor { get; set; }
        public Department Department { get; set; }
    }
}
