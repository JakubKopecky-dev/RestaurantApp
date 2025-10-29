using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.Common.Executors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace MenuService.Command.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ICommandExecutor, CommandExecutor>();

            // Automatická registrace všech CommandHandlerů
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());



            return services;
        }





    }
}
