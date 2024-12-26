namespace ChatbotBuilderEngine.Persistence.Repositories;

public abstract class CudRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context;

    protected CudRepository(AppDbContext context) => Context = context;

    public void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);
}