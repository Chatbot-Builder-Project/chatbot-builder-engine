namespace ChatbotBuilderEngine.Domain.Core.Abstract;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}