using Microsoft.Extensions.DependencyInjection;
using WebApi.Project.Domain;

namespace WebApi.Project.Infrastructure
{
    public class InfrastructureConfig
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}