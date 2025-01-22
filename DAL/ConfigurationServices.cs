using DAL.Repositories.Abstractions;
using DAL.Repositories.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ConfigurationServices
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IDoctorRepository, DoctorRepository>();
            service.AddScoped<IDeparmentRepository, DepartmentRepository>();
        }
    }
}
