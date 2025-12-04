using MassTransit;
namespace MenuService.Command.Api.DepndecyInjection
{
    public static class MassTransitServiceCollectionExtension
    {
        public static IServiceCollection AddMassTransitService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
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

                });

            });



            return services;

        }

    }
}
