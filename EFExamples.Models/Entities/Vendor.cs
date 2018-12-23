using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.Entities
{
    public class Vendor : Entity
    {
        public string Name { get; set; }

        public ICollection<Contractor> Contractors { get; set; }
    }
}
