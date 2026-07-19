using EmployeeManagement.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Api.Data.Configuration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder) 
        {
            // Table Name
            builder.ToTable("Organizations");

            // Primary Key
            builder.HasKey(o => o.Id);

            // Name
            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(o => o.CreatedAt)
                 .IsRequired();

        }
    }
}
