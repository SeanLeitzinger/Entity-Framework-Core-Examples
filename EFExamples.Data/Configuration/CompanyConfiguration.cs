using EFExamples.Models;
using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class CompanyConfiguration : EntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(300).HasDefaultValue("");

            builder.HasMany(m => m.Employees).WithOne(m => m.Company).HasForeignKey(k => k.CompanyId);
            builder.HasMany(m => m.Departments).WithOne(m => m.Company).HasForeignKey(k => k.CompanyId);

            base.Configure(builder);
        }
    }
}
