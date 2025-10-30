using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Infrastructure.Elastic.Indexes
{
    public class MenuItemIndexBuilder(ElasticsearchClient client)
    {
        private readonly ElasticsearchClient _client = client;
        private const string IndexName = "menuitems";

        public async Task EnsureExistsAsync(CancellationToken ct = default)
        {
            var exists = await _client.Indices.ExistsAsync(IndexName, ct);
            if (exists.Exists) return;

            var props = new Properties
            {
                { "id", new KeywordProperty() },
                { "title", new TextProperty() },
                { "unitPrice", new DoubleNumberProperty() },
                { "menuId", new KeywordProperty() },
                { "createdAt", new DateProperty() },
                { "updatedAt", new DateProperty() }
            };

            var response = await _client.Indices.CreateAsync(
                IndexName,
                c => c
                    .Settings(s => s.NumberOfShards(1).NumberOfReplicas(1))
                    .Mappings(m => m.Properties(props)),
                ct
            );

            if (!response.IsValidResponse)
                throw new Exception($"Failed to create index {IndexName}: {response.DebugInformation}");
        }
    }
}
