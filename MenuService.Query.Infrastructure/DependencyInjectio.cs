using MenuService.Query.Application.Interfaces;
using MenuService.Query.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MenuService.Query.Infrastructure
{
    public static class DependencyInjectio
    {
        public static IServiceCollection AddInfrastuctureServices(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();


            return services;
        }
    }
}
