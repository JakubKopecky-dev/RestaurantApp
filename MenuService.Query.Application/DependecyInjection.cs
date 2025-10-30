using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using MenuService.Query.Application.Abstraction.Messaging;


namespace MenuService.Query.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            // Automatická registrace všech CommandHandlerů
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;
        }
    }
}
