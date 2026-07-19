using EmployeeManagement.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Api.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder) 
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(d => d.HrName)
                    .IsRequired()
                    .HasMaxLength(150);

            builder.Property(d => d.CreatedAt)
                    .IsRequired();

            builder.HasOne(d => d.Organization)
                   .WithMany(d => d.Departments)
                   .HasForeignKey(d => d.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);
                                        
        }
    }
}
