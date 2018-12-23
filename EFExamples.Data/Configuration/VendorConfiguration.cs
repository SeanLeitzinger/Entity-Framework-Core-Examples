using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class VendorConfiguration : EntityConfiguration<Vendor>
    {
        public override void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(300).HasDefaultValue("");

            builder.HasMany(m => m.Contractors).WithOne(m => m.Vendor).HasForeignKey(k => k.VendorId);

            base.Configure(builder);
        }
    }
}
