using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExamples.Data.Configuration
{
    public class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
    {
        public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
        {
            builder.HasKey(m => new { m.EmployeeId, m.FileDescriptionId });
            builder.HasOne(m => m.Employee).WithMany(m => m.EmployeeDocuments).HasForeignKey(k => k.EmployeeId);
            builder.HasOne(m => m.FileDescription).WithMany().HasForeignKey(k => k.FileDescriptionId);
        }
    }
}
