using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Persistance.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder) 
        {
            // Table Name
            builder.ToTable("Departments");

            //Primary Key
            builder.HasKey(d => d.Id);

            //Required Profoperties/Columns

            builder.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(d => d.HeadOfDepartment)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(d => d.CreatedAt)
                    .IsRequired();
            
            builder.Property(d => d.IsActive)
                    .IsRequired();

            //Other Properties
            builder.Property(d => d.ModifiedAt);

            // One to * Relationships (Organization to Department)
            builder.HasOne(d => d.Organization)
                    .WithMany(d => d.Departments)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
        }
    }
}
