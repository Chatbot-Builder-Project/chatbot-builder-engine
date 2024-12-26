using ChatbotBuilderEngine.Application.Core.Abstract;
using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Domain.Conversations.Abstract;

namespace ChatbotBuilderEngine.Application.Conversations.SendMessage;

public sealed class SendMessageCommandHandler : ICommandHandler<SendMessageCommand, SendMessageResponse>
{
    private readonly IConversationRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConversationFlowService _conversationFlowService;

    public SendMessageCommandHandler(
        IConversationRepository repository,
        IUnitOfWork unitOfWork,
        IConversationFlowService conversationFlowService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _conversationFlowService = conversationFlowService;
    }

    public async Task<Result<SendMessageResponse>> Handle(
        SendMessageCommand request,
        CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.ConversationId,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result<SendMessageResponse>.Failure(ConversationsApplicationErrors.ConversationNotFound);
        }

        var graph = (await _repository.GetGraphAsync(conversation.Id, cancellationToken))!;

        _conversationFlowService.GraphTraversalService.Graph = graph;
        _conversationFlowService.Conversation = conversation;
        await _conversationFlowService.ProcessInputMessageAsync(request.InputMessage);

        _repository.Update(conversation);
        await _unitOfWork.CommitAsync(cancellationToken);

        var response = new SendMessageResponse(conversation.OutputMessages[^1]);
        return Result<SendMessageResponse>.Success(response);
    }
}