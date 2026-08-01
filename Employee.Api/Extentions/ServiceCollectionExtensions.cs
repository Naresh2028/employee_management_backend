using EmployeeManagement.Api.Service;
using EmployeeManagement.Infrastructure.Repository;
using EmployeeManagements.Application.Interface;

namespace EmployeeManagement.Api.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ApplicaitionServices(this IServiceCollection services) 
        {
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            return services;
        }
    }
}
