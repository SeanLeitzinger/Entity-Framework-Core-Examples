using EFExamples.Models;
using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class EmployeeConfiguration : EntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(m => m.Name, a =>
            {
                new PersonNameConfiguration();
            });
            builder.OwnsOne(m => m.Address, a =>
            {
                new AddressConfiguration();
            });
            builder.Property(p => p.EmployeeId).HasDefaultValueSql(DataConstants.SqlServer.NewSequentialId);

            builder.HasOne(m => m.Company).WithMany(m => m.Employees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.CompanyId);
            builder.HasOne(m => m.Department).WithMany(m => m.Employees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.DepartmentId);

            base.Configure(builder);
        }
    }
}
