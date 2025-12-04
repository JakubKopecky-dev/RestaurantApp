using MassTransit;
using MenuService.Query.SyncWorker.Consumers.Menu;
using MenuService.Query.SyncWorker.Consumers.MenuItem;
namespace MenuService.Query.SyncWorker.DependecyInjection
{
    public static class MassTransitServiceCollectionExtension
    {
        public static IServiceCollection AddMassTransitService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                // register consumers
                x.AddConsumer<MenuCreatedConsumer>();
                x.AddConsumer<MenuUpdatedConsumer>();
                x.AddConsumer<MenuDeletedConsumer>();
                x.AddConsumer<MenuItemCreatedConsumer>();
                x.AddConsumer<MenuItemUpdatedConsumer>();
                x.AddConsumer<MenuItemDeletedConsumer>();

                var host = configuration["RabbitMq:Host"];
                var virtualHost = configuration["RabbitMq:VirtualHost"];
                var userName = configuration["RabbitMq:Username"]!;
                var password = configuration["RabbitMq:Password"]!;

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(host, virtualHost, h =>
                    {
                        h.Username(userName);
                        h.Password(password);
                    });

                    cfg.ConfigureEndpoints(context);
                });

            });



            return services;

        }

    }
}
