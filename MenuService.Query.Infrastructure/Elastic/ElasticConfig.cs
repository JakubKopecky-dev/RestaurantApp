using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Elastic.Clients.Elasticsearch;
namespace MenuService.Query.Infrastructure.Elastic
{
    public static class ElasticConfig
    {
        public static IServiceCollection AddElistic(this IServiceCollection services, IConfiguration configuration)
        {
            Uri uri = new(configuration["Elastic:Uri"]!);


            var settings = new ElasticsearchClientSettings(uri)
                .DefaultIndex("menus"); // fallback

            var client = new ElasticsearchClient(settings);

            services.AddSingleton(client);
            services.AddScoped<ElasticBootstrapper>();

            return services;
        }
    }
}
