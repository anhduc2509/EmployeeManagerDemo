using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Project.Domain
{
    public class DomainConfig
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
        }
    }
}