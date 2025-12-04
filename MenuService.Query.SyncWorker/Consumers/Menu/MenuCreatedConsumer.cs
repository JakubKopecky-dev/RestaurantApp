using Elastic.Clients.Elasticsearch;
using MassTransit;
using MenuService.Query.Domain.Models;
using Shared.Contracts.Events.Menu;

namespace MenuService.Query.SyncWorker.Consumers.Menu
{
    public class MenuCreatedConsumer(ElasticsearchClient elastic) : IConsumer<MenuCreatedEvent>
    {
        private readonly ElasticsearchClient _elastic = elastic;



        public async Task Consume(ConsumeContext<MenuCreatedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            Domain.Models.Menu menu = new()
            {
                Id = message.Id,
                RestaurantName = message.RestaurantName,
                CreatedAt = message.CreatedAt,
                Items = [],
            };

            await _elastic.IndexAsync(menu, i => i.Index("menus"),ct);
        }


    }
}
