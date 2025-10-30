using MenuService.Query.Application.Abstraction.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;


namespace MenuService.Query.Application.Common.Executors
{
    public class QueryExecutor(IServiceScopeFactory scopeFactory) : IQueryExecutor
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;



        public async Task<TResult> Execute<TQuery, TResult>(TQuery query, CancellationToken ct) where TQuery : IQuery<TResult>
        {
            using var scope = _scopeFactory.CreateScope();

            var handle = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

            return await handle.Handle(query, ct);
        }



    }
}
