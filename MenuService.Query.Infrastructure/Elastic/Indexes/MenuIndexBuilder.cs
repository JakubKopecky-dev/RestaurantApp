using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Mapping;
using Elastic.Clients.Elasticsearch.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Infrastructure.Elastic.Indexes
{
    internal class MenuIndexBuilder(ElasticsearchClient client)
    {
        private readonly ElasticsearchClient _client = client;
        private const string IndexName = "menus";

        public async Task EnsureExistsAsync(CancellationToken ct = default)
        {
            var exists = await _client.Indices.ExistsAsync(IndexName, ct);
            if (exists.Exists) return;

            var props = new Properties
            {
                { "id", new KeywordProperty() },
                { "restaurantName", new TextProperty() },
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
