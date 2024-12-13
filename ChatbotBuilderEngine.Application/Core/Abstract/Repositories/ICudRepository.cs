using ChatbotBuilderEngine.Domain.Core.Abstract;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Repositories;

/// <summary>
/// Provides basic Create, Update, and Delete (CUD) operations for entities within a unit of work transaction.
/// Accepts only aggregate roots.
/// </summary>
public interface ICudRepository<in TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    void Add(TAggregateRoot aggregate);
    void Update(TAggregateRoot aggregate);
    void Delete(TAggregateRoot aggregate);
}