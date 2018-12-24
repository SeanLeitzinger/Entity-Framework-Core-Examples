using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class DepartmentContractorConfiguration : IEntityTypeConfiguration<DepartmentContractor>
    {
        public void Configure(EntityTypeBuilder<DepartmentContractor> builder)
        {
            builder.HasKey(m => new { m.ContractorId, m.DepartmentId });
            builder.HasOne(m => m.Contractor).WithMany(m => m.DepartmentContractors).HasForeignKey(k => k.ContractorId);
            builder.HasOne(m => m.Department).WithMany(m => m.DepartmentContractors).HasForeignKey(k => k.DepartmentId);
        }
    }
}
