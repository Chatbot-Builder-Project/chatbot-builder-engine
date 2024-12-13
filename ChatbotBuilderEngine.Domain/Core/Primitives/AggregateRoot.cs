using ChatbotBuilderEngine.Domain.Core.Abstract;

namespace ChatbotBuilderEngine.Domain.Core.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : EntityId<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(TId id, DateTime createdAt, DateTime updatedAt)
        : base(id, createdAt, updatedAt)
    {
    }

    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected AggregateRoot()
    {
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}