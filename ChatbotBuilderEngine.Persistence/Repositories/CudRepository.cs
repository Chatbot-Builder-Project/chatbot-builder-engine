using ChatbotBuilderEngine.Application.Core.Abstract.Repositories;
using ChatbotBuilderEngine.Domain.Core.Primitives;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public class CudRepository<TEntity> : ICudRepository<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _context;

    public CudRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}