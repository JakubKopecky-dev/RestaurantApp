using MenuService.Command.Application.Interfaces.Repositories;
using MenuService.Command.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Persistence
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MenuServiceCommandDbContext>(options => 
            options.UseSqlServer(connectionString));


            // Register repository
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();


            return services;
        }




    }
}
