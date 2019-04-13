using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExamples.Data.Configuration
{
    public class DocumentTypeConfiguration : EntityConfiguration<DocumentType>
    {
        public override void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(300);

            base.Configure(builder);
        }
    }
}
