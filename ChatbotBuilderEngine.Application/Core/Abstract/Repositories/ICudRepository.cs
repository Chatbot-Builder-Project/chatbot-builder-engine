using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Repositories;

/// <summary>
/// Provides basic Create, Update, and Delete (CUD) operations for entities within a unit of work transaction.
/// </summary>
public interface ICudRepository<in TEntity> where TEntity : Entity
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}