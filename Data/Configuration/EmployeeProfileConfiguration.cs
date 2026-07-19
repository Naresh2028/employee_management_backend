using EmployeeManagement.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Api.Data.Configuration
{
    public class EmployeeProfileConfiguration : IEntityTypeConfiguration<EmployeeProfile>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfile> builder) 
        {
            //Table Name
            builder.ToTable("EmployeeProfiles");

            //Primary Key
            builder.HasKey(e => e.Id);

            // Address
            builder.Property(ep => ep.Address)
                   .IsRequired()
                   .HasMaxLength(300);

            // Phone Number
            builder.Property(ep => ep.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            // Joined Date
            builder.Property(ep => ep.JoinedDate)
                   .IsRequired();

            // CreatedAt
            builder.Property(ep => ep.CreatedAt)
                   .IsRequired();

            // ModifiedAt
            builder.Property(ep => ep.ModifiedAt);

        }
    }
}
