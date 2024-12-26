using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Application.Workflows.ListWorkflows;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;

namespace ChatbotBuilderEngine.Application.Workflows;

public interface IWorkflowRepository
{
    void Add(Workflow workflow);
    void Update(Workflow workflow);
    void Delete(Workflow workflow);

    Task<Workflow?> GetByIdAndUserAsync(
        WorkflowId id,
        UserId ownerId,
        bool includeGraph,
        CancellationToken cancellationToken);

    Task<PageResponse<ListWorkflowsResponseItem>> ListByQueryAsync(
        ListWorkflowsQuery query,
        CancellationToken cancellationToken);
}