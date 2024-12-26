using ChatbotBuilderEngine.Application.Chatbots.ListChatbots;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using ChatbotBuilderEngine.Domain.Chatbots;
using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Users;
using ChatbotBuilderEngine.Domain.Workflows;
using Version = ChatbotBuilderEngine.Domain.Chatbots.ValueObjects.Version;

namespace ChatbotBuilderEngine.Application.Chatbots;

public interface IChatbotRepository
{
    void Add(Chatbot chatbot);
    void Update(Chatbot chatbot);
    void Delete(Chatbot chatbot);

    Task<Chatbot?> GetByIdAsync(
        ChatbotId id,
        CancellationToken cancellationToken);

    Task<Chatbot?> GetByIdAndOwnerAsync(
        ChatbotId id,
        UserId ownerId,
        CancellationToken cancellationToken);

    Task<UserId?> GetOwnerIdAsync(
        ChatbotId id,
        CancellationToken cancellationToken);

    Task<Version?> GetLatestVersionAsync(
        WorkflowId id,
        bool isPublic,
        CancellationToken cancellationToken);

    Task<PageResponse<ListChatbotsResponseItem>> ListByQueryAsync(
        ListChatbotsQuery query,
        CancellationToken cancellationToken);

    Task<List<ChatbotId>> ListByWorkflowIdAsync(
        WorkflowId workflowId,
        CancellationToken cancellationToken);
}