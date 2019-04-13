using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExamples.Data.Configuration
{
    public class FileDescriptionConfiguration : EntityConfiguration<FileDescription>
    {
        public override void Configure(EntityTypeBuilder<FileDescription> builder)
        {
            builder.Property(p => p.ContentType).HasDefaultValue("").HasMaxLength(300);
            builder.Property(p => p.Description).HasDefaultValue("").HasMaxLength(1500);
            builder.Property(p => p.FileName).HasDefaultValue("").HasMaxLength(250);
            builder.HasOne(m => m.DocumentType).WithMany().HasForeignKey(k => k.DocumentTypeId);

            base.Configure(builder);
        }
    }
}
