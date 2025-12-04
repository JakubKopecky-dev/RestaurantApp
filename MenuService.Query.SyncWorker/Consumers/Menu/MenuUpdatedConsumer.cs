using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events.Menu;

namespace MenuService.Query.SyncWorker.Consumers.Menu
{
    public class MenuUpdatedConsumer(ElasticsearchClient elastic) : IConsumer<MenuUpdatedEvent>
    {
        private readonly ElasticsearchClient _elastic = elastic;


        public async Task Consume(ConsumeContext<MenuUpdatedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            await _elastic.UpdateAsync(new UpdateRequest<Domain.Models.Menu, Domain.Models.Menu>("menus,", message.Id)
            {
                Doc = new()
                {
                    Id = message.Id,
                    RestaurantName = message.RestaurantName,
                    UpdatedAt = message.UpdatedAt
                }
            }, ct);

        }


    }
}
