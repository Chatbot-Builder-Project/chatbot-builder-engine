using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;

namespace ChatbotBuilderEngine.Domain.Conversations.Abstract;

public interface IConversationFlowService
{
    IGraphTraversalService GraphTraversalService { get; }
    Conversation Conversation { get; set; }
    Task InitializeConversationAsync();
    Task ProcessInputMessageAsync(InputMessage inputMessage);
}