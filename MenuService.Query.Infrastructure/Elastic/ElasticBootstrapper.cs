using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Mapping;
using MenuService.Query.Domain;
using MenuService.Query.Domain.Models;
using MenuService.Query.Infrastructure.Elastic.Indexes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Infrastructure.Elastic
{
    public class ElasticBootstrapper(ElasticsearchClient client)
    {
        private readonly ElasticsearchClient _client = client;

        public async Task EnsureIndicesExistAsync(CancellationToken ct = default)
        {
            var menuIndex = new MenuIndexBuilder(_client);
            await menuIndex.EnsureExistsAsync(ct);

            var menuItemIndex = new MenuItemIndexBuilder(_client);
            await menuItemIndex.EnsureExistsAsync(ct);
        }




    }
}
