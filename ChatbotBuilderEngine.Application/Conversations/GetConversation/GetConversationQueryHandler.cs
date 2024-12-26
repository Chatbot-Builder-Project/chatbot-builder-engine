using ChatbotBuilderEngine.Application.Core.Abstract.Messaging;
using ChatbotBuilderEngine.Application.Core.Shared;

namespace ChatbotBuilderEngine.Application.Conversations.GetConversation;

public sealed class GetConversationQueryHandler : IQueryHandler<GetConversationQuery, GetConversationResponse>
{
    private readonly IConversationRepository _repository;

    public GetConversationQueryHandler(IConversationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetConversationResponse>> Handle(
        GetConversationQuery request,
        CancellationToken cancellationToken)
    {
        var conversation = await _repository.GetByIdAndUserAsync(
            request.Id,
            request.UserId,
            cancellationToken);

        if (conversation is null)
        {
            return Result<GetConversationResponse>.Failure(ConversationsApplicationErrors.ConversationNotFound);
        }

        var response = new GetConversationResponse(
            conversation.Id,
            conversation.CreatedAt,
            conversation.UpdatedAt,
            conversation.Name,
            conversation.ChatbotId);

        return Result<GetConversationResponse>.Success(response);
    }
}