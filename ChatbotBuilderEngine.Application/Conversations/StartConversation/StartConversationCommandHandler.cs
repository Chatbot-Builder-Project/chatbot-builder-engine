using ChatbotBuilderEngine.Application.Core.Abstract;
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Graphs;
using ChatbotBuilderEngine.Domain.Conversations;
using ChatbotBuilderEngine.Domain.Conversations.Abstract;
using ChatbotBuilderEngine.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderEngine.Application.Conversations.StartConversation;

public sealed class StartConversationCommandHandler
    : ICommandHandler<StartConversationCommand, StartConversationResponse>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConversationFlowService _conversationFlowService;

    public StartConversationCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork,
        IConversationFlowService conversationFlowService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _conversationFlowService = conversationFlowService;
    }

    public async Task<Result<StartConversationResponse>> Handle(StartConversationCommand request,
        CancellationToken cancellationToken)
    {
        var chatbot = await _repository.GetChatbotByIdIfAuthorizedAsync(
            request.ChatbotId,
            request.UserId,
            cancellationToken);

        if (chatbot is null)
        {
            return Result<StartConversationResponse>.Failure(ConversationsApplicationErrors.ChatbotNotFound);
        }

        var graph = chatbot.Graph.ToDto().ToDomain();

        var conversation = Conversation.Create(
            new ConversationId(Guid.NewGuid()),
            chatbot.Id,
            graph.Id,
            request.Name);

        _conversationFlowService.GraphTraversalService.Graph = graph;
        _conversationFlowService.Conversation = conversation;
        await _conversationFlowService.InitializeConversationAsync();

        _repository.Add(conversation, graph);
        await _unitOfWork.CommitAsync(cancellationToken);

        var response = new StartConversationResponse(conversation.Id, conversation.OutputMessages[^1]);
        return Result<StartConversationResponse>.Success(response);
    }
}