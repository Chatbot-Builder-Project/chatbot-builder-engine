using ChatbotBuilderEngine.Domain.Core.Abstract;

namespace ChatbotBuilderEngine.Domain.Core.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : EntityId<TId>
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

    /// <inheritdoc/>
    protected AggregateRoot()
    {
    }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; } = DateTime.UtcNow;

    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}