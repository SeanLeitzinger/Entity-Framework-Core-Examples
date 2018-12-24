using EFExamples.Models;
using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class DepartmentConfiguration : EntityConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(300).HasDefaultValue("");

            builder.HasOne(m => m.Company).WithMany(m => m.Departments).HasForeignKey(k => k.CompanyId);
            builder.HasMany(m => m.Employees).WithOne(m => m.Department).HasForeignKey(k => k.DepartmentId);
            builder.HasMany(m => m.DepartmentContractors).WithOne(m => m.Department).HasForeignKey(k => k.DepartmentId);

            base.Configure(builder);
        }
    }
}
