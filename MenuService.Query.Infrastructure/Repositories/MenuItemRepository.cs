using Elastic.Clients.Elasticsearch;
using MenuService.Query.Application.Interfaces;
using MenuService.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Infrastructure.Repositories
{
    public class MenuItemRepository(ElasticsearchClient client) : IMenuItemRepository
    {
        private readonly ElasticsearchClient _client = client;
        private const string IndexName = "menuitems";



        public async Task<MenuItem?> FindByIdAsync(Guid id, CancellationToken ct = default)
        {
            var response = await _client.GetAsync<MenuItem>(id.ToString(), g => g.Index(IndexName), ct);

            return response.Found ? response.Source : null;
        }



        public async Task<IReadOnlyList<MenuItem>> GetAllAsync(CancellationToken ct = default)
        {
            var response = await _client.SearchAsync<MenuItem>(s => s
                .Indices(IndexName)
                .Query(q => q.MatchAll())
                .Size(100), ct);

            return [.. response.Documents];
        }



        public async Task<IReadOnlyList<MenuItem>> SearchByTitleAsync(string title, CancellationToken ct)
        {
            var response = await _client.SearchAsync<MenuItem>(s => s
                .Indices(IndexName)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Title)
                        .Query(title)
                    )
                )
                .Size(100), ct);

            return [.. response.Documents];
        }



        public async Task<IReadOnlyList<MenuItem>> GetMenuItemsByMenuIdAsync(Guid menuId, CancellationToken ct = default)
        {
            var response = await _client.SearchAsync<MenuItem>(s => s
            .Indices(IndexName)
            .Query(q => q
                .Term(t => t
                    .Field(f => f.MenuId)
                    .Value(menuId.ToString())
                )
            )
            .Size(100), ct);

            return [.. response.Documents];
        }




    }
}
