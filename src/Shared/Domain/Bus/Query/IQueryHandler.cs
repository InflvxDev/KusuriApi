using MediatR;

namespace Kusuri.Shared.Domain.Bus.Query;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : Query<TResponse>
{
}
