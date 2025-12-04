using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.Common.Executors;


namespace MenuService.Query.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IQueryExecutor, QueryExecutor>();

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
