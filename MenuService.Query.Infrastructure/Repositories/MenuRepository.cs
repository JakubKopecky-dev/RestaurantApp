using Elastic.Clients.Elasticsearch;
using MenuService.Query.Application.Interfaces;
using MenuService.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Infrastructure.Repositories
{
    public class MenuRepository(ElasticsearchClient client) : IMenuRepository
    {
        private readonly ElasticsearchClient _client = client;
        private const string IndexName = "menus";



        public async Task<Menu?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            var response = await _client.GetAsync<Menu>(id.ToString(), g => g.Index(IndexName), ct);

            return response.Found ? response.Source : null;
        }



        public async Task<IReadOnlyList<Menu>> GetAllAsync(CancellationToken ct = default)
        {
            var response = await _client.SearchAsync<Menu>(s => s
                .Indices(IndexName)
                .Query(q => q.MatchAll())
                .Size(100), ct);

            return [.. response.Documents];
        }



        public async Task<IReadOnlyList<Menu>> SearchByRestaurantNameAsync(string restaurantName, CancellationToken ct)
        {
            var response = await _client.SearchAsync<Menu>(s => s
                .Indices(IndexName)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.RestaurantName)
                        .Query(restaurantName)
                    )
                )
                .Size(100), ct);

            return [.. response.Documents];
        }




    }
}
