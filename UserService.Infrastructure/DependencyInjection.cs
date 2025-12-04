using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Interfaces.Services;
using UserService.Infrastructure.Mapping;
using UserService.Infrastructure.Services;

namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IAuthService, AuthService>();


            services.AddAutoMapper(cfg => { }, typeof(AutomapperConfigurationProfile).Assembly);

            return services;
        }

    }
}
