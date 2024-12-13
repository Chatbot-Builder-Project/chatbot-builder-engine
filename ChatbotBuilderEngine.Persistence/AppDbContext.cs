using ChatbotBuilderEngine.Domain.Core.Abstract;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence;

public class AppDbContext : DbContext
{
    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }

    public override int SaveChanges()
    {
        SetTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        await PublishDomainEventsAsync(cancellationToken);

        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity.GetType().IsAssignableTo(typeof(Entity<>))
                        && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;
            entry.Property("UpdatedAt").CurrentValue = now;

            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = now;
            }
        }
    }

    /// <summary>
    /// Publishes and then clears all domain events that exist within the current transaction.
    /// </summary>
    private async Task PublishDomainEventsAsync(CancellationToken cancellationToken)
    {
        var aggregateRoots = ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(ee => ee.Entity.DomainEvents.Count != 0)
            .ToList();

        var domainEvents = aggregateRoots
            .SelectMany(ee => ee.Entity.DomainEvents)
            .ToList();

        aggregateRoots.ForEach(ee => ee.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select(de => _mediator.Publish(de, cancellationToken));

        await Task.WhenAll(tasks);
    }
}