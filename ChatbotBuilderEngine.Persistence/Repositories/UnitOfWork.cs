using ChatbotBuilderEngine.Application.Core.Abstract;
using ChatbotBuilderEngine.Application.Core.Shared.Notifications;
using ChatbotBuilderEngine.Domain.Core.Abstract;
using MediatR;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await _mediator.Publish(new TransactionStartNotification(), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            await _mediator.Publish(new TransactionSuccessNotification(), cancellationToken);
            await PublishDomainEventsAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            await _mediator.Publish(new TransactionFailureNotification(), cancellationToken);

            throw;
        }
        finally
        {
            await _mediator.Publish(new TransactionCleanupNotification(), cancellationToken);
        }
    }

    /// <summary>
    /// Publishes and then clears all domain events that exist within the current transaction.
    /// </summary>
    private async Task PublishDomainEventsAsync(CancellationToken cancellationToken)
    {
        var aggregateRoots = _context.ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(ee => ee.Entity.DomainEvents.Count != 0)
            .ToList();

        var domainEvents = aggregateRoots
            .SelectMany(ee => ee.Entity.DomainEvents)
            .ToList();

        aggregateRoots.ForEach(ee => ee.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select(domainEvent => _mediator.Publish(domainEvent, cancellationToken));

        await Task.WhenAll(tasks);
    }
}