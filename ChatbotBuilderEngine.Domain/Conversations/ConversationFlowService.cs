using ChatbotBuilderEngine.Domain.Conversations.Abstract;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;
using ChatbotBuilderEngine.Domain.Core;
using ChatbotBuilderEngine.Domain.Graphs;
using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;

namespace ChatbotBuilderEngine.Domain.Conversations;

public sealed class ConversationFlowService : IConversationFlowService
{
    private readonly IGraphTraversalService _graphTraversalService;

    private Graph Graph => _graphTraversalService.Graph;

    public ConversationFlowService(IGraphTraversalService graphTraversalService)
    {
        _graphTraversalService = graphTraversalService;
    }

    private Conversation? _conversation;

    public Conversation Conversation
    {
        get => _conversation ??
               throw new DomainException(ConversationsDomainErrors.ConversationFlow.ConversationNotSet);
        set
        {
            _conversation = value;
            EnsureGraphMatches();
        }
    }

    private void EnsureGraphMatches()
    {
        if (Conversation.GraphId != Graph.Id)
        {
            throw new DomainException(ConversationsDomainErrors.ConversationFlow.GraphMismatch);
        }
    }

    /// <summary>
    /// Initializes the graph and generates the first output message.
    /// </summary>
    public async Task InitializeConversationAsync()
    {
        EnsureGraphMatches();

        await _graphTraversalService.InitializeGraphAsync();

        AddOutput();
    }

    /// <summary>
    /// Takes the input message and traverses the graph to generate the next output message.
    /// </summary>
    /// <param name="inputMessage">The user input message</param>
    public async Task ProcessInputMessageAsync(InputMessage inputMessage)
    {
        EnsureGraphMatches();

        AddInput(inputMessage);

        var nextNodeId = await _graphTraversalService.TraverseAsync(Graph.CurrentNodeId);
        Graph.SetCurrentNodeId(nextNodeId);

        AddOutput();
    }

    private InteractionNode GetCurrentInteractionNode()
    {
        if (Graph.GetCurrentNode() is not InteractionNode interactionNode)
        {
            throw new DomainException(ConversationsDomainErrors.ConversationFlow.NodeIsNotAnInteractionNode);
        }

        return interactionNode;
    }

    private void AddInput(InputMessage inputMessage)
    {
        GetCurrentInteractionNode().SetInteractionInput(inputMessage.Input);

        Conversation.AddInputMessage(inputMessage);
    }

    private void AddOutput()
    {
        var interactionOutput = GetCurrentInteractionNode().GetInteractionOutput();

        Conversation.AddOutputMessage(OutputMessage.Create(interactionOutput));
    }
}