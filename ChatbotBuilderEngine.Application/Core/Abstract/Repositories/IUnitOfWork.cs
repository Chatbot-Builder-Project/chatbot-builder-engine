namespace ChatbotBuilderEngine.Application.Core.Abstract.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}