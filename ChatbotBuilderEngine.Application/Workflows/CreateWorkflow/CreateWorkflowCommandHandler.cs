using ChatbotBuilderEngine.Application.Core.Abstract;
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Application.Graphs;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows.CreateWorkflow;

public sealed class CreateWorkflowCommandHandler : ICommandHandler<CreateWorkflowCommand, CreateResponse<WorkflowId>>
{
    private readonly IWorkflowRepository _workflowRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkflowCommandHandler(
        IWorkflowRepository workflowRepository,
        IUnitOfWork unitOfWork)
    {
        _workflowRepository = workflowRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateResponse<WorkflowId>>> Handle(
        CreateWorkflowCommand request,
        CancellationToken cancellationToken)
    {
        var workflow = Workflow.Create(
            new WorkflowId(Guid.NewGuid()),
            request.Name,
            request.Description,
            request.OwnerId,
            request.Graph.ToDomain());

        _workflowRepository.Add(workflow);

        await _unitOfWork.CommitAsync(cancellationToken);

        var result = new CreateResponse<WorkflowId>(workflow.Id);
        return Result<CreateResponse<WorkflowId>>.Success(result);
    }
}