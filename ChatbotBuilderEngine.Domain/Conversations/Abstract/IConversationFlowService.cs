using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderEngine.Domain.Conversations.Abstract;

public interface IConversationFlowService
{
    Conversation Conversation { get; set; }
    Task InitializeConversationAsync();
    Task ProcessInputMessageAsync(InputMessage inputMessage);
}