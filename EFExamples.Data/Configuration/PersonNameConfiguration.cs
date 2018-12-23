using EFExamples.Models.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Data.Configuration
{
    public class PersonNameConfiguration : IEntityTypeConfiguration<PersonName>
    {
        public void Configure(EntityTypeBuilder<PersonName> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(300).HasDefaultValue("");
            builder.Property(p => p.LastName).HasMaxLength(300).HasDefaultValue("");
            builder.Ignore(p => p.FullName);
        }
    }
}
