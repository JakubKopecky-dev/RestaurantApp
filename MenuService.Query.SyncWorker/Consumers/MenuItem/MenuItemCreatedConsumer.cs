using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events.MenuItems;

namespace MenuService.Query.SyncWorker.Consumers.MenuItem
{
    public class MenuItemCreatedConsumer(ElasticsearchClient elastic) : IConsumer<MenuItemCreatedEvent>
    {
        private readonly ElasticsearchClient _elastic = elastic;



        public async Task Consume(ConsumeContext<MenuItemCreatedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            Domain.Models.MenuItem item = new()
            {
                Id = message.Id,
                Title = message.Title,
                MenuId = message.MenuId,
                CreatedAt = message.CreatedAt,
                UnitPrice = message.UnitPrice
            };


            await _elastic.IndexAsync(item, i => i.Index("menuitems"), ct);
        }


    }
}
