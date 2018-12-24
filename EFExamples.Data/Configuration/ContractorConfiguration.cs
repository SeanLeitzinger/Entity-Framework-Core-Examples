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
                a.Property(p => p.FirstName).HasMaxLength(300)
                    .HasColumnName("FirstName")
                    .HasDefaultValue("");
                a.Property(p => p.LastName).HasMaxLength(300)
                    .HasColumnName("LastName")
                    .HasDefaultValue("");
                a.Ignore(p => p.FullName);
            });
            builder.OwnsOne(m => m.Address, a =>
            {
                a.Property(p => p.StreetAddress).HasMaxLength(600)
                    .HasColumnName("StreetAddress")
                    .HasDefaultValue("");
                a.Property(p => p.City).HasMaxLength(150)
                    .HasColumnName("City")
                    .HasDefaultValue("");
                a.Property(p => p.State).HasMaxLength(60)
                    .HasColumnName("State")
                    .HasDefaultValue("");
                a.Property(p => p.ZipCode).HasMaxLength(12)
                    .HasColumnName("ZipCode")
                    .HasDefaultValue("");
            });

            builder.HasMany(m => m.DepartmentContractors).WithOne(m => m.Contractor)
                .HasForeignKey(k => k.ContractorId);
            builder.HasOne(m => m.Vendor).WithMany(m => m.Contractors)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.VendorId);

            base.Configure(builder);
        }
    }
}
