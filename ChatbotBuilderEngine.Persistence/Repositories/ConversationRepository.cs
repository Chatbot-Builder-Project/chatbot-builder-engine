using ChatbotBuilderEngine.Application.Conversations;
using ChatbotBuilderEngine.Application.Conversations.ListConversations;
using ChatbotBuilderEngine.Application.Conversations.ListMessages;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Chatbots;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Conversations;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;
using ChatbotBuilderEngine.Persistence.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence.Repositories;

public sealed class ConversationRepository : CudRepository<Conversation>, IConversationRepository
{
    public ConversationRepository(AppDbContext context) : base(context)
    {
    }

    public void Add(Conversation conversation, Graph conversationGraph)
    {
        if (conversation.GraphId != conversationGraph.Id)
        {
            throw new InvalidOperationException("Conversation and graph must have the same id");
        }

        Context.Add(conversationGraph);
        base.Add(conversation);
    }

    public async Task<Chatbot?> GetChatbotByIdIfAuthorizedAsync(
        ChatbotId chatbotId,
        UserId userId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Chatbot>()
            .Include(c => c.Graph)
            .Where(c =>
                c.Id == chatbotId &&
                (c.IsPublic ||
                 EF.Property<Workflow>(c, "Workflow").OwnerId == userId))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Conversation?> GetByIdAndUserAsync(
        ConversationId conversationId,
        UserId userId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Conversation>()
            .Where(c =>
                c.Id == conversationId &&
                EF.Property<Workflow>(EF.Property<Chatbot>(c, "Chatbot"), "Workflow").OwnerId == userId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PageResponse<ListConversationResponseItem>> ListByQueryAsync(
        ListConversationsQuery query,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Conversation>()
            .Where(c =>
                EF.Property<Workflow>(EF.Property<Chatbot>(c, "Chatbot"), "Workflow").OwnerId == query.UserId &&
                (query.Search == null || c.Name.Contains(query.Search)) &&
                (query.ChatbotId == null || c.ChatbotId == query.ChatbotId))
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new ListConversationResponseItem(
                c.Id,
                c.CreatedAt,
                c.UpdatedAt,
                c.Name,
                c.ChatbotId))
            .PageResponseAsync(
                query.PageParams,
                cancellationToken);
    }

    public async Task<ListMessagesResponse> ListMessagesAsync(
        ConversationId conversationId,
        PageParams pageParams,
        CancellationToken cancellationToken)
    {
        var inputMessages = await Context.Set<Conversation>()
            .Where(c => c.Id == conversationId)
            .SelectMany(c => c.InputMessages)
            .PageResponseAsync(pageParams, cancellationToken);

        var outputMessages = await Context.Set<Conversation>()
            .Where(c => c.Id == conversationId)
            .SelectMany(c => c.OutputMessages)
            .PageResponseAsync(pageParams, cancellationToken);

        return new ListMessagesResponse(inputMessages, outputMessages);
    }

    public async Task<Graph?> GetGraphAsync(
        ConversationId conversationId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Graph>()
            .Where(g => EF.Property<ConversationId>(g, "ConversationId") == conversationId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<ConversationId>> ListByChatbotIdAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Conversation>()
            .Where(c => c.ChatbotId == chatbotId)
            .Select(c => c.Id)
            .ToListAsync(cancellationToken);
    }
}