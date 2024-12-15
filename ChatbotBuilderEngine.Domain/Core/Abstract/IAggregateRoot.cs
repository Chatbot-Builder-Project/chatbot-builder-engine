namespace ChatbotBuilderEngine.Domain.Core.Abstract;

public interface IAggregateRoot
{
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }

    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}