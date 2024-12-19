using ChatbotBuilderEngine.Domain.Chatbots.ValueObjects;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Core.Primitives;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;

namespace ChatbotBuilderEngine.Domain.Conversations;

public sealed class Conversation : AggregateRoot<ConversationId>
{
    private readonly List<InputMessage> _inputMessages = [];
    private readonly List<OutputMessage> _outputMessages = [];

    public string Name { get; private set; } = null!;
    public ChatbotId ChatbotId { get; } = null!;
    public GraphId GraphId { get; } = null!;
    public IReadOnlyList<InputMessage> InputMessages => _inputMessages;
    public IReadOnlyList<OutputMessage> OutputMessages => _outputMessages;

    private Conversation(
        ConversationId id,
        ChatbotId chatbotId,
        GraphId graphId,
        string name)
        : base(id)
    {
        ChatbotId = chatbotId;
        Name = name;
        GraphId = graphId;
    }

    /// <inheritdoc/>
    private Conversation()
    {
    }

    public static Conversation Create(
        ConversationId id,
        ChatbotId chatbotId,
        GraphId graphId,
        string name)
    {
        return new Conversation(id, chatbotId, graphId, name);
    }

    public void AddInputMessage(InputMessage inputMessage)
    {
        if (inputMessage.CreatedAt < _outputMessages.LastOrDefault()?.CreatedAt)
        {
            throw new DomainException(ConversationsDomainErrors.Conversation.InputMessageIsOutOfOrder);
        }

        _inputMessages.Add(inputMessage);
    }

    public void AddOutputMessage(OutputMessage outputMessage)
    {
        if (outputMessage.CreatedAt < _inputMessages.LastOrDefault()?.CreatedAt)
        {
            throw new DomainException(ConversationsDomainErrors.Conversation.OutputMessageIsOutOfOrder);
        }

        _outputMessages.Add(outputMessage);
    }
}