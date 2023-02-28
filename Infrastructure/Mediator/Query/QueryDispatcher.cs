﻿using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Query
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<QueryResult<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return handler.Handle(query, cancellation);
        }
    }
}
    