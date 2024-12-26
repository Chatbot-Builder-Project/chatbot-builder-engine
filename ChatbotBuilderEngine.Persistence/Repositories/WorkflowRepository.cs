using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Application.Workflows;
using ChatbotBuilderEngine.Application.Workflows.ListWorkflows;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;
using ChatbotBuilderEngine.Persistence.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public sealed class WorkflowRepository : CudRepository<Workflow>, IWorkflowRepository
{
    public WorkflowRepository(AppDbContext context) : base(context)
    {
    }

    public new void Update(Workflow workflow)
    {
        var existingWorkflow = Context.Set<Workflow>()
            .Include(w => w.Graph)
            .First(w => w.Id == workflow.Id);

        Context.Set<Graph>().Remove(existingWorkflow.Graph);

        base.Update(workflow);
    }

    public async Task<Workflow?> GetByIdAndUserAsync(
        WorkflowId id,
        UserId ownerId,
        bool includeGraph,
        CancellationToken cancellationToken)
    {
        var queryable = Context.Set<Workflow>()
            .Where(w =>
                w.Id == id &&
                w.OwnerId == ownerId);

        if (includeGraph)
        {
            queryable = queryable.Include(w => w.Graph);
        }

        return await queryable.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<ListWorkflowsResponseItem>> ListByQueryAsync(
        ListWorkflowsQuery query,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Workflow>()
            .Where(w => w.OwnerId == query.OwnerId)
            .Where(w => query.Search == null
                        || w.Name.Contains(query.Search)
                        || w.Description.Contains(query.Search))
            .Select(w => new ListWorkflowsResponseItem(
                w.Id,
                w.OwnerId,
                w.Name,
                w.Description,
                w.CreatedAt,
                w.UpdatedAt))
            .PageResponseAsync(query.PageParams, cancellationToken);
    }
}