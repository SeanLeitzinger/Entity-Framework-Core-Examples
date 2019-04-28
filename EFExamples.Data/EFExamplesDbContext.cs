using EFExamples.Data.Configuration;
using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFExamples.Data
{
    public class EFExamplesDbContext : DbContext
    {
        public EFExamplesDbContext()
        {
        }

        public EFExamplesDbContext(DbContextOptions<EFExamplesDbContext> options) : base(options) { }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentContractor> DepartmentContractor { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDocument> EmployeeDocument { get; set; }
        public virtual DbSet<FileDescription> FileDescription { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new ContractorConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new DepartmentContractorConfiguration());
            builder.ApplyConfiguration(new DocumentTypeConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new EmployeeDocumentConfiguration());
            builder.ApplyConfiguration(new FileDescriptionConfiguration());
            builder.ApplyConfiguration(new VendorConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source=DESKTOP-J803PRQ;Initial Catalog=EFExamples;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            AddAuditValues();

            return base.SaveChanges();
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditValues();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddAuditValues()
        {
            var entities = ChangeTracker.Entries().Where(x => (x.Entity is Entity)
                && (x.State == EntityState.Added || x.State == EntityState.Detached || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.Entity is Entity)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((Entity)entity.Entity).DateCreated = DateTime.Now;
                    }

                    if (entity.State == EntityState.Modified)
                    {
                        ((Entity)entity.Entity).DateUpdated = DateTime.Now;
                    }
                }
            }
        }
    }
}
