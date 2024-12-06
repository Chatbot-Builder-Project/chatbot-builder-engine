using Ardalis.Specification;
using ChatbotBuilderEngine.Application.Core.Abstract.Specifications;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Repositories;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Checks if any entity satisfies the given specification.
    /// </summary>
    /// <param name="spec">The specification to test against the entities.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>True if any entity satisfies the specification; otherwise, false.</returns>
    Task<bool> ExistsAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves the count of all entities that satisfy the given specification.
    /// </summary>
    /// <param name="spec">The specification to test against the entities.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>The count of entities that satisfy the specification.</returns>
    Task<int> CountAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a list of <typeparamref name="TEntity"/> according to the specification.
    /// </summary>
    /// <param name="spec">Specification that will be applied on the query</param>
    /// <param name="cancellationToken">Request cancellation token</param>
    /// <typeparam name="TEntity">Output of applying the specification on the query</typeparam>
    /// <returns>All outputs that obey the specification</returns>
    Task<IEnumerable<TEntity>> ListAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a list of <typeparamref name="TEntityDto"/> according to the specification.
    /// </summary>
    /// <param name="spec">Specification that will be applied on the query</param>
    /// <param name="cancellationToken">Request cancellation token</param>
    /// <typeparam name="TEntityDto">Output of applying the specification on the query</typeparam>
    /// <returns>All outputs that obey the specification</returns>
    Task<IEnumerable<TEntityDto>> ListAsync<TEntityDto>(
        Specification<TEntity, TEntityDto> spec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves the first <typeparamref name="TEntity"/> according to the specification.
    /// </summary>
    /// <param name="spec">Specification that will be applied on the query.</param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    /// <typeparam name="TEntity">Output of applying the specification on the query.</typeparam>
    /// <returns>The first output that obeys the specification or default if no match is found.</returns>
    Task<TEntity?> GetAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves the first <typeparamref name="TEntityDto"/> according to the specification.
    /// </summary>
    /// <param name="spec">Specification that will be applied on the query.</param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    /// <typeparam name="TEntityDto">Output of applying the specification on the query.</typeparam>
    /// <returns>The first output that obeys the specification or default if no match is found.</returns>
    Task<TEntityDto?> GetAsync<TEntityDto>(
        Specification<TEntity, TEntityDto> spec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a paged list of <typeparamref name="TEntity"/> according to the specification.
    /// </summary>
    /// <param name="spec">Specification that will be applied on the query.</param>
    /// <param name="pageParams">Parameters for pagination (page number, page size).</param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    /// <typeparam name="TEntity">Output of applying the specification on the query.</typeparam>
    /// <returns>A page response containing the outputs that obey the specification.</returns>
    Task<PageResponse<TEntity>> PageAsync(
        Specification<TEntity> spec,
        PageParams pageParams,
        CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a paged list of <typeparamref name="TEntityDto"/> according to the specification.
    /// </summary>
    /// <param name="spec">Specification that will be applied on the query.</param>
    /// <param name="pageParams">Parameters for pagination (page number, page size).</param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    /// <typeparam name="TEntityDto">Output of applying the specification on the query.</typeparam>
    /// <returns>A page response containing the outputs that obey the specification.</returns>
    Task<PageResponse<TEntityDto>> PageAsync<TEntityDto>(
        Specification<TEntity, TEntityDto> spec,
        PageParams pageParams,
        CancellationToken cancellationToken);

    /// <summary>
    /// Aggregates data to a single result object according to the specified query and aggregate specifications.
    /// </summary>
    /// <param name="querySpec">Specification that will be applied to the entities before aggregation.</param>
    /// <param name="aggregateSpec">Specification that defines the aggregation logic.</param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    /// <typeparam name="TAggregateDto">The type that the result of the aggregation will be projected to.</typeparam>
    /// <returns>The aggregated result projected to <typeparamref name="TAggregateDto"/> or null if no match is found.</returns>
    Task<TAggregateDto?> AggregateAsync<TAggregateDto>(
        Specification<TEntity> querySpec,
        AggregateSpec<TEntity, TAggregateDto> aggregateSpec,
        CancellationToken cancellationToken);

    /// <summary>
    /// Aggregates data to a single result according to the specified query and aggregate specifications.
    /// </summary>
    /// <param name="querySpec">Specification that will be applied to the entities before aggregation.</param>
    /// <param name="aggregateSpec">Specification that defines the aggregation logic.</param>
    /// <param name="cancellationToken">Request cancellation token.</param>
    /// <typeparam name="TEntityDto">The type that the entities will be projected to before aggregation
    /// (according to the specification).</typeparam>
    /// <typeparam name="TAggregateDto">The type that the result of the aggregation will be projected to.</typeparam>
    /// <returns>The aggregated result projected to <typeparamref name="TAggregateDto"/> or null if no match is found.</returns>
    Task<TAggregateDto?> AggregateAsync<TEntityDto, TAggregateDto>(
        Specification<TEntity, TEntityDto> querySpec,
        AggregateSpec<TEntityDto, TAggregateDto> aggregateSpec,
        CancellationToken cancellationToken);
}