using ChatbotBuilderEngine.Application.Abstract.Repositories;
using ChatbotBuilderEngine.Domain.Entities;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public class CudRepository<TEntity> : ICudRepository<TEntity> where TEntity : BaseEntity
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