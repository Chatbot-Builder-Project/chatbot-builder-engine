using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;

namespace ChatbotBuilderEngine.Application.Workflows.ListWorkflows;

public sealed class ListWorkflowsQueryHandler : IQueryHandler<ListWorkflowsQuery, ListWorkflowsResponse>
{
    private readonly IWorkflowRepository _repository;

    public ListWorkflowsQueryHandler(IWorkflowRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListWorkflowsResponse>> Handle(
        ListWorkflowsQuery request,
        CancellationToken cancellationToken)
    {
        var workflows = await _repository.ListByQueryAsync(request, cancellationToken);
        var response = new ListWorkflowsResponse(workflows);
        return Result<ListWorkflowsResponse>.Success(response);
    }
}