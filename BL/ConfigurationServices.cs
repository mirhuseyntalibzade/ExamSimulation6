using BL.Services.Abstractions;
using BL.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BL
{
    public static class ConfigurationServices
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddFluentValidationAutoValidation();
            service.AddFluentValidationClientsideAdapters();

            service.AddScoped<IDoctorService, DoctorService>();
            service.AddScoped<IDepartmentService, DepartmentService>();
            service.AddScoped<IAuthService, AuthService>();
        }
    }
}
