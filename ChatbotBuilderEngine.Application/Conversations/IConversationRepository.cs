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

namespace ChatbotBuilderEngine.Application.Conversations;

public interface IConversationRepository
{
    void Add(Conversation conversation, Graph conversationGraph);
    void Update(Conversation conversation);
    void Delete(Conversation conversation);

    Task<Chatbot?> GetChatbotByIdIfAuthorizedAsync(
        ChatbotId chatbotId,
        UserId userId,
        CancellationToken cancellationToken);

    Task<Conversation?> GetByIdAndUserAsync(
        ConversationId conversationId,
        UserId userId,
        CancellationToken cancellationToken);

    Task<PageResponse<ListConversationResponseItem>> ListByQueryAsync(
        ListConversationsQuery query,
        CancellationToken cancellationToken);

    Task<ListMessagesResponse> ListMessagesAsync(
        ConversationId conversationId,
        PageParams pageParams,
        CancellationToken cancellationToken);

    Task<Graph?> GetGraphAsync(
        ConversationId conversationId,
        CancellationToken cancellationToken);

    Task<List<ConversationId>> ListByChatbotIdAsync(
        ChatbotId chatbotId,
        CancellationToken cancellationToken);
}