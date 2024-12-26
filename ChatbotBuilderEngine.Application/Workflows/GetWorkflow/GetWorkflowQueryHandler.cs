using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Graphs;

namespace ChatbotBuilderEngine.Application.Workflows.GetWorkflow;

public sealed class GetWorkflowQueryHandler : IQueryHandler<GetWorkflowQuery, GetWorkflowResponse>
{
    private readonly IWorkflowRepository _repository;

    public GetWorkflowQueryHandler(IWorkflowRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetWorkflowResponse>> Handle(GetWorkflowQuery request, CancellationToken cancellationToken)
    {
        var workflow = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.OwnerId,
            includeGraph: true,
            cancellationToken);

        if (workflow is null)
        {
            return Result<GetWorkflowResponse>.Failure(WorkflowsApplicationErrors.WorkflowNotFound);
        }

        var response = new GetWorkflowResponse(
            workflow.Id,
            workflow.OwnerId,
            workflow.CreatedAt,
            workflow.UpdatedAt,
            workflow.Name,
            workflow.Description,
            workflow.Graph.ToDto());

        return Result<GetWorkflowResponse>.Success(response);
    }
}