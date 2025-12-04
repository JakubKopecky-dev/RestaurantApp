using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events.MenuItems;

namespace MenuService.Query.SyncWorker.Consumers.MenuItem
{
    public class MenuItemDeletedConsumer(ElasticsearchClient elastic) : IConsumer<MenuItemDeletedEvent>
    {
        private readonly ElasticsearchClient _elastic = elastic;



        public async Task Consume(ConsumeContext<MenuItemDeletedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            await _elastic.DeleteAsync<Domain.Models.MenuItem>(message.Id, i=> i.Index("menuitems"), ct);
        }

    }
}
