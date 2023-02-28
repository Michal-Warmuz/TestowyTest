namespace Mediator.Query
{
    public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery
    {
        Task<QueryResult<TQueryResult>> Handle(TQuery query, CancellationToken cancellation);
    }
}
