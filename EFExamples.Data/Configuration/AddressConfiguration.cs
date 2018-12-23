using EFExamples.Models.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.StreetAddress).HasMaxLength(600).HasDefaultValue("");
            builder.Property(p => p.City).HasMaxLength(150).HasDefaultValue("");
            builder.Property(p => p.State).HasMaxLength(60).HasDefaultValue("");
            builder.Property(p => p.ZipCode).HasMaxLength(12).HasDefaultValue("");
        }
    }
}
