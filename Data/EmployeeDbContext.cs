using EmployeeManagement.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Data
{
    public class EmployeeDbContext : DbContext
    {
        //DbContextOptions contains EF Core configuration, such as the database provider, connection string
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeDbContext).Assembly);
        }

    }
}
