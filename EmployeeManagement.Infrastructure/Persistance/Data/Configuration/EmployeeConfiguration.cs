using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Persistance.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder) 
        {
            // Table Name
            builder.ToTable("Employees");

            //Primary Key
            builder.HasKey(e => e.Id);

            //Employee Name
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

            // Salary
            builder.Property(e => e.Salary)
                   .HasPrecision(18, 2)
                   .IsRequired();

            // CreatedAt
            builder.Property(e => e.CreatedAt)
                   .IsRequired();

            // ModifiedAt
            builder.Property(e => e.ModifiedAt);

            //Navigation 1 to many (Department to Employees)
            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Navigation 1 to 1 (Employee to EmployeeProfile)
            builder.HasOne(e => e.EmployeeProfile)
                   .WithOne(ep => ep.Employee)
                   .HasForeignKey<EmployeeProfile>(ep => ep.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
