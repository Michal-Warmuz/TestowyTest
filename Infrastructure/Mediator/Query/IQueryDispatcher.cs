namespace Mediator.Query
{
    public interface IQueryDispatcher
    {
        Task<QueryResult<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation) where TQuery : IQuery;
    }
}
