using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using ChatbotBuilderEngine.Application.Core.Abstract.Repositories;
using ChatbotBuilderEngine.Application.Core.Abstract.Specifications;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(spec)
            .AnyAsync(cancellationToken);
    }

    public async Task<int> CountAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(spec)
            .CountAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> ListAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(spec)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntityDto>> ListAsync<TEntityDto>(
        Specification<TEntity, TEntityDto> spec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(spec)
            .ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(
        Specification<TEntity> spec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(spec)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntityDto?> GetAsync<TEntityDto>(
        Specification<TEntity, TEntityDto> spec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(spec)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<TEntity>> PageAsync(
        Specification<TEntity> spec,
        PageParams pageParams,
        CancellationToken cancellationToken)
    {
        var query = _context.Set<TEntity>()
            .WithSpecification(spec);

        return await PageResponseAsync(query, pageParams, cancellationToken);
    }

    public async Task<PageResponse<TEntityDto>> PageAsync<TEntityDto>(
        Specification<TEntity, TEntityDto> spec,
        PageParams pageParams,
        CancellationToken cancellationToken)
    {
        var query = _context.Set<TEntity>()
            .WithSpecification(spec);

        return await PageResponseAsync(query, pageParams, cancellationToken);
    }

    private static async Task<PageResponse<T>> PageResponseAsync<T>(
        IQueryable<T> query,
        PageParams parameters,
        CancellationToken cancellationToken)
    {
        return new PageResponse<T>
        {
            TotalCount = await query.CountAsync(cancellationToken),
            Items = await query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync(cancellationToken)
        };
    }

    public async Task<TAggregateDto?> AggregateAsync<TAggregateDto>(
        Specification<TEntity> querySpec,
        AggregateSpec<TEntity, TAggregateDto> aggregateSpec,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(querySpec)
            .GroupBy(e => 1)
            .WithSpecification(aggregateSpec)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TAggregateDto?> AggregateAsync<TEntityDto, TAggregateDto>(
        Specification<TEntity, TEntityDto> querySpecification,
        AggregateSpec<TEntityDto, TAggregateDto> aggregateSpecification,
        CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .WithSpecification(querySpecification)
            .GroupBy(e => 1)
            .WithSpecification(aggregateSpecification)
            .FirstOrDefaultAsync(cancellationToken);
    }
}