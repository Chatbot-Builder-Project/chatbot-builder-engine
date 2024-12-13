using ChatbotBuilderEngine.Application.Core.Abstract.Repositories;
using ChatbotBuilderEngine.Domain.Core.Abstract;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public class CudRepository<TAggregateRoot> : ICudRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
{
    private readonly AppDbContext _context;

    public CudRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(TAggregateRoot aggregate)
    {
        _context.Set<TAggregateRoot>().Add(aggregate);
    }

    public void Update(TAggregateRoot aggregate)
    {
        _context.Set<TAggregateRoot>().Update(aggregate);
    }

    public void Delete(TAggregateRoot aggregate)
    {
        _context.Set<TAggregateRoot>().Remove(aggregate);
    }
}