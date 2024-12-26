using ChatbotBuilderEngine.Application.Core.Abstract;
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Graphs;

namespace ChatbotBuilderEngine.Application.Workflows.UpdateWorkflow;

public sealed class UpdateWorkflowCommandHandler : ICommandHandler<UpdateWorkflowCommand>
{
    private readonly IWorkflowRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorkflowCommandHandler(
        IWorkflowRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWorkflowCommand request, CancellationToken cancellationToken)
    {
        var workflow = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.OwnerId,
            includeGraph: false,
            cancellationToken);

        if (workflow is null)
        {
            return Result.Failure(WorkflowsApplicationErrors.WorkflowNotFound);
        }

        workflow.Update(
            request.Name,
            request.Description,
            request.Graph.ToDomain());

        _repository.Update(workflow);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}