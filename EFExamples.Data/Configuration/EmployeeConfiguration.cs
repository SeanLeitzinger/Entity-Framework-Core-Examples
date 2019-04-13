using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFExamples.Data.Configuration
{
    public class EmployeeConfiguration : EntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
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
            builder.Property(p => p.EmployeeId).HasDefaultValueSql(DataConstants.SqlServer.NewSequentialId);
            builder.HasIndex(p => p.EmployeeId).HasName("IX_Employee_EmployeeId").ForSqlServerIsClustered(false);

            builder.HasOne(m => m.Company).WithMany(m => m.Employees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.CompanyId);
            builder.HasOne(m => m.Department).WithMany(m => m.Employees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(k => k.DepartmentId);
            builder.HasMany(m => m.EmployeeDocuments).WithOne(m => m.Employee).HasForeignKey(k => k.EmployeeId);

            base.Configure(builder);
        }
    }
}
