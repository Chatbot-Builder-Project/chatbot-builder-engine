using ChatbotBuilderEngine.Application.Chatbots;
using ChatbotBuilderEngine.Application.Chatbots.ListChatbots;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Chatbots;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;
using ChatbotBuilderEngine.Persistence.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using Version = ChatbotBuilderEngine.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public sealed class ChatbotRepository : CudRepository<Chatbot>, IChatbotRepository
{
    public ChatbotRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Chatbot?> GetByIdAsync(ChatbotId id, CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Chatbot?> GetByIdAndOwnerAsync(
        ChatbotId id,
        UserId ownerId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c =>
                c.Id == id &&
                EF.Property<Workflow>(c, "Workflow").OwnerId == ownerId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserId?> GetOwnerIdAsync(ChatbotId id, CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.Id == id)
            .Select(c => EF.Property<Workflow>(c, "Workflow").OwnerId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Version?> GetLatestVersionAsync(WorkflowId id, bool isPublic, CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.WorkflowId == id && c.IsPublic == isPublic)
            .Select(c => c.Version)
            .OrderByDescending(v => v.Major)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<ListChatbotsResponseItem>> ListByQueryAsync(
        ListChatbotsQuery query,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c =>
                query.Search == null ||
                c.Name.Contains(query.Search) ||
                c.Description.Contains(query.Search))
            .Where(c =>
                !query.IncludeOnlyPersonal ||
                EF.Property<Workflow>(c, "Workflow").OwnerId == query.UserId)
            .Where(c =>
                !query.IncludeOnlyLatest ||
                c.Version == Context.Set<Chatbot>()
                    .Where(c2 => c2.WorkflowId == c.WorkflowId && c2.IsPublic == c.IsPublic)
                    .Select(c2 => c2.Version)
                    .OrderByDescending(v => v.Major)
                    .FirstOrDefault())
            .Where(c =>
                query.WorkflowId == null ||
                c.WorkflowId == query.WorkflowId)
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new ListChatbotsResponseItem(
                c.Id,
                EF.Property<Workflow>(c, "Workflow").OwnerId,
                c.CreatedAt,
                c.UpdatedAt,
                c.Name,
                c.Description,
                c.IsPublic))
            .PageResponseAsync(
                query.PageParams,
                cancellationToken);
    }

    public async Task<List<ChatbotId>> ListByWorkflowIdAsync(
        WorkflowId workflowId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Where(c => c.WorkflowId == workflowId)
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);
    }
}