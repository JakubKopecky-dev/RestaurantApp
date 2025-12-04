using Elastic.Clients.Elasticsearch;
using MassTransit;
using Shared.Contracts.Events.Menu;

namespace MenuService.Query.SyncWorker.Consumers.Menu
{
    public class MenuDeletedConsumer(ElasticsearchClient elastic) : IConsumer<MenuDeletedEvent>
    {
        private readonly ElasticsearchClient _elastic = elastic;



        public async Task Consume(ConsumeContext<MenuDeletedEvent> context)
        {
            var message = context.Message;
            var ct = context.CancellationToken;

            await _elastic.DeleteAsync<Domain.Models.Menu>(message.Id, d => d.Index("menus"),ct);


            await _elastic.DeleteByQueryAsync<Domain.Models.MenuItem>(d => d
                .Indices("menuitems")
                .Query(q => q
                    .Term(t => t
                        .Field("menuId")
                            .Value(message.Id.ToString())
                    )
                )
                .Refresh(true),ct
             );

        }
             

    }
}
