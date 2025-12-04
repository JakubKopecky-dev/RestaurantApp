using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events.MenuItems;

namespace MenuService.Query.SyncWorker.Consumers.MenuItem
{
    public class MenuItemUpdatedConsumer(ElasticsearchClient elastic) : IConsumer<MenuItemUpdatedEvent>
    {
        private readonly ElasticsearchClient _elastic = elastic;



        public async Task Consume(ConsumeContext<MenuItemUpdatedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            await _elastic.UpdateAsync(new UpdateRequest<Domain.Models.MenuItem, Domain.Models.MenuItem>("menuitems", message.Id)
            {
                Doc = new()
                {
                    Id = message.Id,
                    Title = message.Title,
                    UnitPrice = message.UnitPrice,
                    MenuId = message.MenuId,
                    UpdatedAt = message.UpdatedAt
                }
            }, ct);


        }
    }
}
