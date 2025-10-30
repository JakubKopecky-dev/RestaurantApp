using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Abstraction.Messaging
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query, CancellationToken ct) where TQuery : IQuery<TResult>;
    }
}
