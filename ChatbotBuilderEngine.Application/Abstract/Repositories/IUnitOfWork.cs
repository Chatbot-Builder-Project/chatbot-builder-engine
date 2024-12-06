namespace ChatbotBuilderEngine.Application.Abstract.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}