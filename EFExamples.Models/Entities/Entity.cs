using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
