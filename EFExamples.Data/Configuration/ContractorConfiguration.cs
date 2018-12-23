using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class ContractorConfiguration : EntityConfiguration<Contractor>
    {
        public override void Configure(EntityTypeBuilder<Contractor> builder)
        {
            builder.OwnsOne(m => m.Name, a =>
            {
                new PersonNameConfiguration();
            });
            builder.OwnsOne(m => m.Address, a =>
            {
                new AddressConfiguration();
            });

            builder.HasOne(m => m.Department).WithMany(m => m.Contractors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.DepartmentId);
            builder.HasOne(m => m.Vendor).WithMany(m => m.Contractors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.VendorId);

            base.Configure(builder);
        }
    }
}
