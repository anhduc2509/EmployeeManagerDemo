using Microsoft.Extensions.DependencyInjection;
using WebApi.Project.Application.Service;
using WebApi.Project.Domain.Entity;

namespace WebApi.Project.Application
{
    public class ApplicationConfig
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}